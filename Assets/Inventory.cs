using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public SerializableDictionary<Resource, int> Resources { get; private set; }

    public int GetResourceCount(Resource type)
    {
        if(Resources.TryGetValue(type, out int currentCount))
        {
            return currentCount;
        }
        else
        {
            return 0;
        }
    }

    public int AddResources(Resource type, int count)
    {
        return Resources[type] += count;
    }
}
