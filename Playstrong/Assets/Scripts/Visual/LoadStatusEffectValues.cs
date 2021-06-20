using System;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Visual
{
    public class LoadStatusEffectValues : MonoBehaviour, ILoadStatusEffectValues
    {
        private IHeroStatusEffect _heroStatusEffect;

        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void LoadValues(IStatusEffectAsset statusEffect, int counters)
        {
         
            _heroStatusEffect.StatusEffectAsset = statusEffect;
            _heroStatusEffect.StatusEffectType = statusEffect.StatusEffectType;
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffect.CounterUpdate;

            _heroStatusEffect.Counters = counters;
            _heroStatusEffect.Icon.sprite = statusEffect.Icon;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

         


        }
    }
}
