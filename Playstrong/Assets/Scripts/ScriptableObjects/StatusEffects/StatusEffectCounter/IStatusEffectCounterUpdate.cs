using Logic;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
    
    
    /// <summary>
    /// Determines when the status effect (buff or debuff) counters
    /// get updated, similar to skill cooldown
    /// </summary>
    public interface IStatusEffectCounterUpdate
    {
        void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect);

        void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect);
    }
}
