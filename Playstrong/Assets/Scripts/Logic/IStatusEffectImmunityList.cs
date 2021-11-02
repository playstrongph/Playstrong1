using System.Collections.Generic;

namespace Logic
{
    public interface IStatusEffectImmunityList
    {
        List<IHeroStatusEffectImmunity> HeroImmunities { get; }
        void AddToStatusEffectImmunityList(IHeroStatusEffectImmunity heroStatusEffectImmunity);

        void RemoveFromStatusEffectImmunityList(IHeroStatusEffectImmunity heroStatusEffectImmunity);
    }
}