using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolType", menuName = "Proto/ToolType")]
public class ToolType : ScriptableObject 
{
    [field: SerializeField] public string Display { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
}
