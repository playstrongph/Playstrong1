using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Others;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic
{
    
    /// <summary>
    /// For use by Actions and Effects, NOT by normal reduction during hero turns
    /// </summary>
    public class DecreaseStatusEffectCounters : MonoBehaviour, IDecreaseStatusEffectCounters
    {
        private IHeroStatusEffect _heroStatusEffect;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
            
        }

        public void DecreaseCounters(int value, ICoroutineTreesAsset coroutineTreesAsset)
        {
           _logicTree = coroutineTreesAsset.MainLogicTree;
           _visualTree = coroutineTreesAsset.MainVisualTree;
           
           _logicTree.AddCurrent(DecreaseCounters(value));
        }

        private IEnumerator DecreaseCounters(int value)
        {
            _heroStatusEffect.Counters -= value;

            if (_heroStatusEffect.Counters <= 0)
            {
                _heroStatusEffect.Counters = 0;
                _heroStatusEffect.RemoveStatusEffect.RemoveEffect(_heroStatusEffect.TargetHero);
            }

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
