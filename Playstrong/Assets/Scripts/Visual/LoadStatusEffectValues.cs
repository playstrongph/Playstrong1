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
            var statusEffectAsset = statusEffect;

            _heroStatusEffect.Counters = counters;
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

         


        }
    }
}
