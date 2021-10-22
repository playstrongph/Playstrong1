using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

   
    public class StatusEffectUpdateTimingAsset : ScriptableObject, IStatusEffectUpdateTiming
    {
        
        
        public virtual void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }

        public virtual void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }
        
        public virtual void UpdateCountersAtEvent(IHeroStatusEffect heroStatusEffect)
        {
           
        }

        public virtual IEnumerator UpdateCountersCoroutine(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;

            //Don't update counters cast on the CasterHero at the end of turn
            heroStatusEffect.StatusEffectChangeCounters.ReduceStatusEffectCounters(heroStatusEffect);
            
            logicTree.EndSequence();
            yield return null;
        }

        public virtual void UpdateCounterAction(IHero thisHero)
        {
            
        }
        public virtual void UpdateCounterAction(IHero thisHero,IHero targetHero)
        {
            
        }
        





    }
}
