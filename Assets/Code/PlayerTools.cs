using System;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public Vector3 unequippedPos;
    public Quaternion unequippedRot;
    public Vector3 equippedPos;
    public Quaternion equippedRot;
    public Vector3 hitPos;
    public Quaternion hitRot;

    public GameObject axe;
    public GameObject pickAxe;
    public GameObject bucket;

    private GameObject currentTool;
        
    public void Equip(PlayerToolType type)
    {
        if (currentTool) currentTool.SetActive(false);
        currentTool = FetchTool(type);
        if (currentTool) currentTool.SetActive(true);
        SetToolVisible(0f);
    }

    public void SetToolVisible(float t)
    {
        if (!currentTool) return;
        currentTool.transform.localPosition = Vector3.Lerp(unequippedPos, equippedPos, t);
        currentTool.transform.localRotation = Quaternion.Lerp(unequippedRot, equippedRot, t);
    }

    public void SetToolHitTime(float t)
    {
        if (!currentTool) return;
        currentTool.transform.localPosition = Vector3.Lerp(equippedPos, hitPos, t);
        currentTool.transform.localRotation = Quaternion.Lerp(equippedRot, hitRot, t);
    }

    private GameObject FetchTool(PlayerToolType type)
    {
        switch (type)
        {
            case PlayerToolType.None:
                return null;
            case PlayerToolType.Axe:
                return axe;
            case PlayerToolType.Pickaxe:
                return pickAxe;
            case PlayerToolType.Bucket:
                return bucket;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}