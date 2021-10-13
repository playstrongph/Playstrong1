using Interfaces;
using Logic;

namespace ScriptableObjects.StatusEffects.Instance
{
    /// <summary>
    /// Sets the allowed instances of buffs/debuffs.
    /// Single - 1 instance with updating counters
    /// Multiple - more than 1 instance, counters updated through skill effects
    /// FixedCounters - 1 instance and fixed counter of 1.  (Stun)
    /// ImmuneCounters - can't increase/decrease counters through effects (Bomb)
    /// </summary>
    public interface IStatusEffectInstance
    {
        void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero);

        //void IncreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        //void DecreaseCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        //void SetCounters(IHeroStatusEffect existingStatusEffect, IHero targetHero, int counters);

        //void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero);

    }
}
