using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvesting: MonoBehaviour
{
    public Tool Tool
    {
        get
        {
            return _tool;
        }
        set
        {
            if(_tool != value)
            {
                _tool = value;
                UpdateSprite();
            }
        }
    }

    private void UpdateSprite()
    {
        if (_tool != null)
        {
            _renderer.sprite = _tool.Sprite;
        }
        else
        {
            _renderer.sprite = null;
        }
    }

    [SerializeField] private Tool _tool;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

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
