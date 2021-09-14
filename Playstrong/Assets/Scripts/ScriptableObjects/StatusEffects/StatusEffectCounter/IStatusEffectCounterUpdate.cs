using System.Collections;
using Interfaces;
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

        void UpdateCountersAtEvent(IHeroStatusEffect heroStatusEffect);

        IEnumerator UpdateCountersCoroutine(IHeroStatusEffect heroStatusEffect);

        void UpdateCounterAction(IHero thisHero);

        void UpdateCounterAction(IHero thisHero, IHero targetHero);


    }
}
