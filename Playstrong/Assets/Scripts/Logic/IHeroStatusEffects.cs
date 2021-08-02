using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public interface IHeroStatusEffects
    {
        GameObject HeroStatusEffectPrefab { get; }

        GameObject StatusEffectPreviewPrefab { get; }
        Canvas StatusEffectsCanvas { get; }
        IStatusEffectsPanel StatusEffectsPanel { get; }
        IStatusEffectsVisual StatusEffectsVisual { get; }
        IHeroBuffEffects HeroBuffEffects { get; }
        IHeroDebuffEffects HeroDebuffEffects { get; }

        IUpdateStatusEffectCounters UpdateStatusEffectCounters { get; }

       

       
    }
}