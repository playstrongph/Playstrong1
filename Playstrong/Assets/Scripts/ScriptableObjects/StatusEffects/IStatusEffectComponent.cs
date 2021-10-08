using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffectComponent
    {
        IStatusEffectAsset StatusEffectAsset {get; set;}

        ScriptableObject statusEffectAssetObject { get; }
        List<IStandardActionAsset> StandardActionAssets { get; }
        List<ScriptableObject> StandardActionObjectAssets { get;}
        List<IActionTargets> ActionTargetAssets {get;}
        List<ScriptableObject> ActionTargetObjectAssets { get;}

        void ApplyStatusEffect(IHero hero);

        void UnapplyStatusEffect(IHero hero);


    }
}