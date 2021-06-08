using System;
using Logic;
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

        public void LoadValues(int counters)
        {
            var statusEffectAsset = _heroStatusEffect.StatusEffectAsset;
          

            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon.sprite;
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            
            _heroStatusEffect.Counters = counters;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

         


        }
    }
}
