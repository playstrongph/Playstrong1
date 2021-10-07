using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Others;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic
{
    
    
    /// <summary>
    /// Normal Reduction method used during start turn/end turn
    /// Fixed Reduction value of 1.
    /// </summary>
    
    public class ReduceStatusEffectCounters : MonoBehaviour, IReduceStatusEffectCounters
    {
        private IHeroStatusEffect _heroStatusEffect;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private int fixedReduction = 1;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
            
        }

        public void ReduceCounters(ICoroutineTreesAsset coroutineTreesAsset)
        {
           _logicTree = coroutineTreesAsset.MainLogicTree;
           _visualTree = coroutineTreesAsset.MainVisualTree;
           
           _logicTree.AddCurrent(LogicReduceCountersEnumerator());
           //TODO: potentially include statuseffectinstance UpdateCounters for fixedInstance purposes
        }

        private IEnumerator LogicReduceCountersEnumerator()
        {
            _heroStatusEffect.Counters -= fixedReduction;
            
            _visualTree.AddCurrent(VisualReduceCountersEnumerator());
            
            if(_heroStatusEffect.Counters <=0)
                _heroStatusEffect.RemoveStatusEffect.RemoveEffect(_heroStatusEffect.StatusEffectTargetHero);

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualReduceCountersEnumerator()
        {
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            _visualTree.EndSequence();
            yield return null;
        }
    }
}
