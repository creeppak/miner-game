using UnityEngine;

public class CrystalBlock : Block
{
    public override Color GizmoColor => Color.magenta;
    
    public override PlayerToolType EquipToolType => PlayerToolType.Pickaxe;
}