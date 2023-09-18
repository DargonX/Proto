using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvesting: MonoBehaviour
{
    [field: SerializeField] public Tool Tool { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Harvestable harvestable = other.GetComponent<Harvestable>();

        if(harvestable != null && harvestable.HarvestingType == Tool.Type)
        {
            int amountToHarvest = UnityEngine.Random.Range(Tool.MinHarvest, Tool.MaxHarvest);

            harvestable.TryHarvest(Tool.Type, amountToHarvest);
        }
    }
}
