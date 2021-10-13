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

        public IEnumerator UpdateCountersCoroutine(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(heroStatusEffect.CoroutineTreesAsset);
            
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
