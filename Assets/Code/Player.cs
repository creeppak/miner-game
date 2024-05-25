using System;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float actionTime = .5f;
    public PlayerTools tools;
    
    private int rotation;
    private Vector2Int position;
    private PlayerState activeState;

    private Vector2Int LookDirection => GetLookDirection(rotation);

    private Vector2Int GetLookDirection(int rot)
    {
        switch (rot % 4)
        {
            case 0:
                return new Vector2Int(0, 1);
            case 1:
            case -3:
                return new Vector2Int(1, 0);;
            case 2:
            case -2:
                return new Vector2Int(0, -1);
            case 3:
            case -1:
                return new Vector2Int(-1, 0);
            default:
                throw new Exception("this is not possible");
        }
    }

    private void Awake()
    {
        position = BlocksMap.Instance.ToBlockPosition(transform.position);
        transform.position = CalcPosition(position);
        SetState(new IdlePlayerState());
    }

    private Vector3 CalcPosition(Vector2Int blockPos) => BlocksMap.Instance.ToWorldPosition(blockPos);

    private void Update()
    {
        activeState?.Update();
    }

    public void Move(int direction)
    {
        if (!activeState.AllowInput) return;
        
        SetState(new MovePlayerState(direction));
    }

    public void Rotate(int direction)
    {
        if (!activeState.AllowInput) return;
        
        SetState(new RotatePlayerState(direction));
    }

    private Quaternion CalcRotation(int blockRotation)
    {
        return Quaternion.AngleAxis(90 * blockRotation, Vector3.up);
    }

    private void SetState(PlayerState state)
    {
        activeState?.OnExit();
        activeState = state;
        activeState.SetContext(this);
        activeState.OnEnter();
    }
    
    public abstract class PlayerState
    {
        protected Player Player { get; private set; }

        public virtual bool AllowInput => false;

        public void SetContext(Player player)
        {
            Player = player;
        }

        public virtual void OnEnter(){}
        public virtual void OnExit(){}
        public virtual void Update(){}
    }

    public class IdlePlayerState : PlayerState
    {
        public override bool AllowInput => true;
    }

    public class MovePlayerState : PlayerState
    {
        private readonly int direction;
        private float startTime;
        private Vector3 from;
        private Vector3 to;
        private Vector2Int newModelPosition;

        public MovePlayerState(int direction)
        {
            this.direction = direction;
        }

        public override void OnEnter()
        {
            newModelPosition = Player.position + Player.LookDirection * direction;
            if (!CanMove(newModelPosition))
            {
                Player.SetState(new IdlePlayerState());
                return;
            }
            
            startTime = Time.time;
            from = Player.transform.position;
            to = Player.CalcPosition(newModelPosition);
            var lookAtBlockPosition = newModelPosition + Player.LookDirection * direction;;
            Player.tools.Equip(BlocksMap.Instance.GetBlock(lookAtBlockPosition)?.EquipToolType ?? PlayerToolType.None);
        }

        private bool CanMove(Vector2Int modelPosition)
        {
            return BlocksMap.Instance.GetBlock(modelPosition) == null;
        }

        public override void Update()
        {
            var t = Mathf.Clamp01((Time.time - startTime) / Player.actionTime);
            Player.transform.position = Vector3.Lerp(from, to, t);
            Player.tools.SetToolVisible(t);

            if (t == 1f)
            {
                Player.position = newModelPosition;
                Player.SetState(new IdlePlayerState());
            }
        }
    }

    public class RotatePlayerState : PlayerState
    {
        private readonly int direction;
        private float startTime;
        private Quaternion from;
        private Quaternion to;

        public RotatePlayerState(int direction)
        {
            this.direction = direction;
        }

        public override void OnEnter()
        {
            startTime = Time.time;
            from = Player.CalcRotation(Player.rotation);
            to = Player.CalcRotation(Player.rotation + direction);
            var newLookingAtBlockPos = Player.GetLookDirection(Player.rotation + direction) + Player.position;
            Player.tools.Equip(BlocksMap.Instance.GetBlock(newLookingAtBlockPos)?.EquipToolType ?? PlayerToolType.None);
        }

        public override void Update()
        {
            var t = Mathf.Clamp01((Time.time - startTime) / Player.actionTime);
            Player.transform.rotation = Quaternion.Lerp(from, to, t);
            Player.tools.SetToolVisible(t);

            if (t == 1f)
            {
                Player.rotation += direction;
                Player.SetState(new IdlePlayerState());
            }
        }
    }
}