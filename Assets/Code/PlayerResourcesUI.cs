using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerResourcesUI : MonoBehaviour
    {
        public PlayerResources resources;
        public TMP_Text wood;
        public TMP_Text rock;
        public TMP_Text crystal;

        private void Update()
        {
            wood.text = resources.Get(ResourceType.Wood).ToString("0");
            rock.text = resources.Get(ResourceType.Rock).ToString("0");
            crystal.text = resources.Get(ResourceType.Crystals).ToString("0");
        }
    }
}