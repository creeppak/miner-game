using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public Vector2Int blockPos;
    public virtual PlayerToolType EquipToolType => PlayerToolType.None;
    public virtual bool Hittable => true;
    
    protected virtual void Awake()
    {
        BlocksMap.Instance.Register(this);

        blockPos = BlocksMap.Instance.ToBlockPosition(transform.position);
    }

    protected virtual void OnDestroy()
    {
        BlocksMap.Instance.Unregister(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        Gizmos.DrawWireCube(transform.position + new Vector3(0f, BlocksMap.blockSize / 2, 0f), new Vector3(BlocksMap.blockSize, BlocksMap.blockSize, BlocksMap.blockSize));
        // Gizmos.DrawWireCube(transform.position, new Vector3(BlocksMap.blockSize, BlocksMap.blockSize, BlocksMap.blockSize));
    }

    public virtual void OnHit(PlayerResources player) {}
    
    public virtual Color GizmoColor => Color.white;
}