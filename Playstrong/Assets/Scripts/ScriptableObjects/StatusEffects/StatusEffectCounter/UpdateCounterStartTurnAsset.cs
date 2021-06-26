﻿using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectCounter
{
   

    [CreateAssetMenu(fileName = "UpdateCounterStartTurn", menuName = "SO's/Status Effects/Counters Update/UpdateCounterStartTurn")]
    public class UpdateCounterStartTurnAsset : ScriptableObject, IStatusEffectCounterUpdate
    {
        private ICoroutineTree _logicTree;
        private int _value = 1;
        
        public void UpdateCountersStartTurn(IHeroStatusEffect heroStatusEffect)
        {
            _logicTree = heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            _logicTree.AddCurrent(UpdateCounters(heroStatusEffect));
        }

        public void UpdateCountersEndTurn(IHeroStatusEffect heroStatusEffect)
        {
            
        }

        private IEnumerator UpdateCounters(IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffect.ReduceStatusEffectCounters.ReduceCounters(_value, heroStatusEffect.CoroutineTreesAsset);
            
            _logicTree.EndSequence();
            yield return null;
        }






    }
}