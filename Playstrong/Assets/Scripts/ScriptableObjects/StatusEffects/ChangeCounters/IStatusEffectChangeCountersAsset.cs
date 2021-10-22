using Logic;

namespace ScriptableObjects.StatusEffects.Instance
{
    public interface IStatusEffectChangeCountersAsset
    {
        void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters);
        void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect,int counters);
        //TEST
        void SetChangeableToTempNoDecrease(IHeroStatusEffect heroStatusEffect);
        void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect,int counters);
        void ReduceStatusEffectCounters(IHeroStatusEffect heroStatusEffect);
    }
}