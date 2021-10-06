using System.Collections.Generic;
using Logic;
using ScriptableObjects.StandardActions;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffectComponent
    {
        IStatusEffectAsset StatusEffectAsset { get; set; }
        List<IStandardActionAsset> StandardActionAssets { get; }
        List<IActionTargets> ActionTargetAssets { get; }
    }
}