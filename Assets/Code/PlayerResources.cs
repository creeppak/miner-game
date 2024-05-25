using System.Collections.Generic;
using UnityEngine;

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

    public void ClearAll()
    {
        resources[ResourceType.Wood] = 0;
        resources[ResourceType.Rock] = 0;
        resources[ResourceType.Crystals] = 0;
    }
}