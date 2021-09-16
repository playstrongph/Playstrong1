using Interfaces;
using Logic;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    public interface IStatusEffectType
    {

        void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);

        void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);

        void IncreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        void DecreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        void SetCountersValue(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero);
        






    }
    
    
}