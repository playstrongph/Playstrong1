using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

   
    public class StatusEffectCounterUpdateAsset : ScriptableObject, IStatusEffectCounterUpdate
    {
        
        
        public virtual void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }

        public virtual void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
           
        }

        protected IEnumerator UpdateCountersCoroutine(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(heroStatusEffect.CoroutineTreesAsset);
            
            logicTree.EndSequence();
            yield return null;
        }






    }
}
