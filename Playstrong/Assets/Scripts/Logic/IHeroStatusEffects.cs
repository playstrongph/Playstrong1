using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public interface IHeroStatusEffects
    {
        IHeroStatusEffects HeroStatusEffectPrefab { get; }
        Canvas StatusEffectsCanvas { get; }
        IStatusEffectsPanel StatusEffectsPanel { get; }
        IStatusEffectsVisual StatusEffectsVisual { get; }
        IHeroBuffEffects HeroBuffEffects { get; }
        IHeroDebuffEffects HeroDebuffEffects { get; }
    }
}