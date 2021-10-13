using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Others;
using UnityEngine;
using UnityEngine.Rendering;

namespace Logic
{
    public class SetStatusEffectCounters : MonoBehaviour, ISetStatusEffectCounters
    {
        private IHeroStatusEffect _heroStatusEffect;
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void SetCounters(int value)
        {
            var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(LogicSetCountersEnumerator(value));
        }

        private IEnumerator LogicSetCountersEnumerator(int value)
        {
            var logicTree = _heroStatusEffect.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _heroStatusEffect.CoroutineTreesAsset.MainVisualTree;
            
            _heroStatusEffect.Counters = value;
            
            visualTree.AddCurrent(VisualSetCountersEnumerator(value));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualSetCountersEnumerator(int value)
        {
            var visualTree = _heroStatusEffect.CoroutineTreesAsset.MainVisualTree;
            
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            visualTree.EndSequence();
            yield return null;
        }
    }
}
