using UnityEngine;

public class RockBlock : Block
{
    public override PlayerToolType EquipToolType => PlayerToolType.Pickaxe;

    public override Color GizmoColor => Color.grey;
}