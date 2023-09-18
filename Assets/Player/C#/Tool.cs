using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Proto/Tool")]

public class Tool: ScriptableObject
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public ToolType Type { get; private set; }
    [field: SerializeField] public int MinHarvest { get; private set; } = 1;
    [field: SerializeField] public int MaxHarvest { get; private set; } = 3;
}
