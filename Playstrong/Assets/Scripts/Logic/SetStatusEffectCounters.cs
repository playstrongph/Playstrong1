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
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
            
        }

        public void SetCounters(int value, ICoroutineTreesAsset coroutineTreesAsset)
        {
          
           _logicTree = coroutineTreesAsset.MainLogicTree;
           _visualTree = coroutineTreesAsset.MainVisualTree;
           
           _logicTree.AddCurrent(LogicSetCountersEnumerator(value));
           
           //TODO: potentially include statuseffectinstance UpdateCounters for fixedInstance purposes
        }

        private IEnumerator LogicSetCountersEnumerator(int value)
        {
            _heroStatusEffect.Counters = value;
            
            _visualTree.AddCurrent(VisualSetCountersEnumerator(value));

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualSetCountersEnumerator(int value)
        {
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            _visualTree.EndSequence();
            yield return null;
        }
    }
}
