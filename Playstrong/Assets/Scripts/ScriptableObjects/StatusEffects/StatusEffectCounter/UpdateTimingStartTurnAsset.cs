using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterStartTurn", menuName = "SO's/Status Effects/Counters Update/UpdateCounterStartTurn")]
    public class UpdateTimingStartTurnAsset :  StatusEffectUpdateTimingAsset
    {
        private ICoroutineTree _logicTree;

        public override void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(UpdateCountersCoroutine(heroStatusEffect));
        }
        
        public override IEnumerator UpdateCountersCoroutine(IHeroStatusEffect heroStatusEffect)
        {
            var logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            //Update Counters Normally 
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(heroStatusEffect.CoroutineTreesAsset);

            logicTree.EndSequence();
            yield return null;
        }

        






    }
}
