﻿using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterEndTurnAsset", menuName = "SO's/Status Effects/Counters Update/UpdateCounterEndTurnAsset")]
    public class UpdateCounterEndTurnAsset : ScriptableObject, IStatusEffectCounterUpdate
    {
        private ICoroutineTree _logicTree;
        
        
        public void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
            
        }

        public void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
            _logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            _logicTree.AddCurrent(UpdateCounters(heroStatusEffect));
        }

        private IEnumerator UpdateCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(heroStatusEffect.CoroutineTreesAsset);
            
            _logicTree.EndSequence();
            yield return null;
        }






    }
}
