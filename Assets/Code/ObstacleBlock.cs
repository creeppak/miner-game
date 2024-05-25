using UnityEngine;

public class ObstacleBlock : Block
{
    public override Color GizmoColor => Color.red;
    public override bool Hittable => false;
}