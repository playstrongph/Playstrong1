using System.Collections.Generic;
using Logic;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffectComponent
    {
        IStatusEffectAsset StatusEffectAsset {get; set;}
        List<IStandardActionAsset> StandardActionAssets { get; }
        List<ScriptableObject> StandardActionObjectAssets { get;}
        List<IActionTargets> ActionTargetAssets {get;}

       
    }
}