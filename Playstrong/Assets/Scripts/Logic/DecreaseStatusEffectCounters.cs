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
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void DecreaseCounters(int value)
        {
            var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(DecreaseCountersCoroutine(value));
        }

        private IEnumerator DecreaseCountersCoroutine(int value)
        {
            var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _heroStatusEffect.CoroutineTreesAsset.MainVisualTree;
            
            _heroStatusEffect.Counters -= value;

            if (_heroStatusEffect.Counters <= 0)
            {
                _heroStatusEffect.Counters = 0;
                _heroStatusEffect.RemoveStatusEffect.RemoveEffect(_heroStatusEffect.StatusEffectTargetHero);
            }

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
