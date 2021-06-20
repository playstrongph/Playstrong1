using Logic;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
    public interface IStatusEffectCounterUpdate
    {
        void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect);

        void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect);
    }
}
