using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]

public class StateAnimationDictionary : SerializableDictionary<CHaracterState, DirectionalAnimationSet>
{
    public AnimationClip GetFacingClipFromState(CHaracterState characterState, Vector2 facingDirection)
    {
        if (TryGetValue(characterState, out DirectionalAnimationSet animationSet))
        {
            return animationSet.GetFcingClip(facingDirection);
        }
        else
        {
            Debug.LogError($"Character state {characterState.name} is not found in the StateAnimations dictionary");
        }

        return null;
    }
}

