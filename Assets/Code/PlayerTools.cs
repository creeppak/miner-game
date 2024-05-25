using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerTools : MonoBehaviour
    {
        public Vector3 unequippedPos;
        public Quaternion unequippedRot;
        public Vector3 equippedPos;
        public Quaternion equippedRot;

        public GameObject axe;
        public GameObject pickAxe;

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}