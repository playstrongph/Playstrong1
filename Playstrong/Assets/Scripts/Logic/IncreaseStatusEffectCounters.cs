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
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
            
        }

        public void IncreaseCounters(int value, ICoroutineTreesAsset coroutineTreesAsset)
        {
           _logicTree = coroutineTreesAsset.MainLogicTree;
           _visualTree = coroutineTreesAsset.MainVisualTree;
           
           _logicTree.AddCurrent(IncreaseCounters(value));
        }

        private IEnumerator IncreaseCounters(int value)
        {
            _heroStatusEffect.Counters += value;
            
            _visualTree.AddCurrent(SetCountersVisual(value));

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator SetCountersVisual(int value)
        {
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            _visualTree.EndSequence();
            yield return null;
        }
    }
}
