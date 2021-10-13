using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Others;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic
{
    public class IncreaseStatusEffectCounters : MonoBehaviour, IIncreaseStatusEffectCounters
    {
        private IHeroStatusEffect _heroStatusEffect;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void IncreaseCounters(int value)
        {
           var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
           
           logicTree.AddCurrent(IncreaseCountersCoroutine(value));
        }

        private IEnumerator IncreaseCountersCoroutine(int value)
        {
            var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _heroStatusEffect.CoroutineTreesAsset.MainVisualTree;
            
            _heroStatusEffect.Counters += value;
            
            visualTree.AddCurrent(SetCountersVisual(value));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator SetCountersVisual(int value)
        {
            var visualTree = _heroStatusEffect.CoroutineTreesAsset.MainVisualTree;
            
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            visualTree.EndSequence();
            yield return null;
        }
    }
}
