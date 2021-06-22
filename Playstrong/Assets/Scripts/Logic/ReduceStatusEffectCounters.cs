using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Others;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic
{
    public class ReduceStatusEffectCounters : MonoBehaviour, IReduceStatusEffectCounters
    {
        private IHeroStatusEffect _heroStatusEffect;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
            
        }

        public void ReduceCounters(int value, ICoroutineTreesAsset coroutineTreesAsset)
        {
           _logicTree = coroutineTreesAsset.MainLogicTree;
           _visualTree = coroutineTreesAsset.MainVisualTree;
           
           _logicTree.AddCurrent(LogicReduceCountersEnumerator(value));
           //TODO: potentially include statuseffectinstance UpdateCounters for fixedInstance purposes
        }

        private IEnumerator LogicReduceCountersEnumerator(int value)
        {
            _heroStatusEffect.Counters -= value;
            
            _visualTree.AddCurrent(VisualReduceCountersEnumerator(value));

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualReduceCountersEnumerator(int value)
        {
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            _visualTree.EndSequence();
            yield return null;
        }
    }
}
