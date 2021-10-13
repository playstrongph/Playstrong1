using Logic;

namespace ScriptableObjects.StatusEffects.Instance
{
    public interface IStatusEffectChangeCountersAsset
    {
        void IncreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect);
        void DecreaseStatusEffectCounters(IHeroStatusEffect heroStatusEffect);
        void SetStatusEffectCountersToValue(IHeroStatusEffect heroStatusEffect);
    }
}