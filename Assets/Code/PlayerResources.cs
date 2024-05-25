using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerResources : MonoBehaviour
    {
        private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>
        {
            { ResourceType.Wood, 0 },
            { ResourceType.Rock, 0 },
            { ResourceType.Crystals, 0 }
        };

        public void Add(ResourceType type, int count)
        {
            resources[type] += count;
        }

        public int Get(ResourceType type)
        {
            return resources[type];
        }
    }
}