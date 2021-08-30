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
         
            //TEST
            var statusEffectObject = statusEffect as ScriptableObject;
            var uniqueStatusEffectObject = Instantiate(statusEffectObject);
            var uniqueStatusEffect = uniqueStatusEffectObject as IStatusEffectAsset;

            //_heroStatusEffect.StatusEffectAsset = statusEffect;
            _heroStatusEffect.StatusEffectAsset = CloneStatusEffectAsset(statusEffect);
            
            _heroStatusEffect.StatusEffectType = statusEffect.StatusEffectType;
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffect.UpdateTiming;
            _heroStatusEffect.StatusEffectInstance = statusEffect.StatusEffectInstance;

            _heroStatusEffect.Counters = counters;
            _heroStatusEffect.Icon.sprite = statusEffect.Icon;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
        }

        private IStatusEffectAsset CloneStatusEffectAsset(IStatusEffectAsset statusEffect)
        {
            var statusEffectObject = statusEffect as ScriptableObject;
            var statusEffectCloneObject = Instantiate(statusEffectObject);
            var statusEffectClone = statusEffectCloneObject as IStatusEffectAsset;

            return statusEffectClone;
        }


    }
}
