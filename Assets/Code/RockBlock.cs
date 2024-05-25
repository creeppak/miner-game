using UnityEngine;

public class RockBlock : Block
{
    public HittableConfiguration hittableConfiguration;
    
    public override PlayerToolType EquipToolType => PlayerToolType.Pickaxe;

    public override Color GizmoColor => Color.grey;

    private int hits;

    public override void OnHit(PlayerResources player)
    {
        if (++hits >= hittableConfiguration.timeToHit)
        {
            hits = 0;
            player.Add(ResourceType.Rock, 1);
        }
    }
}