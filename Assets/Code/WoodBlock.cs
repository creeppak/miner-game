using UnityEngine;

public class WoodBlock : Block
{
    public override PlayerToolType EquipToolType => PlayerToolType.Axe;

    public override Color GizmoColor => Color.green;

    public override void OnHit(PlayerResources playerResources)
    {
        playerResources.Add(ResourceType.Wood, 1);
    }
}