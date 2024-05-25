using UnityEngine;

public class CrystalBlock : Block
{
    public HittableConfiguration hittableConfiguration;
    
    public override Color GizmoColor => Color.magenta;
    
    public override PlayerToolType EquipToolType => PlayerToolType.Pickaxe;

    private int hits;

    public override void OnHit(PlayerResources player)
    {
        if (++hits >= hittableConfiguration.timeToHit)
        {
            hits = 0;
            player.Add(ResourceType.Crystals, 1);
        }
    }
}