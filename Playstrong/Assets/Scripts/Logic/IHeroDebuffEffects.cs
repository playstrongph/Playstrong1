using System.Collections.Generic;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroDebuffEffects
    {
        List<IDebuffEffectAsset> HeroDebuffs { get; }
    }
}