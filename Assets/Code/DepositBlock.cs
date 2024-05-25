using UnityEngine;

public class DepositBlock : Block
{
    public override PlayerToolType EquipToolType => PlayerToolType.Bucket;
    public override Color GizmoColor => Color.blue;

    public override void OnHit(PlayerResources resources)
    {
        // todo send all to Nikola
        resources.ClearAll();
    }
}