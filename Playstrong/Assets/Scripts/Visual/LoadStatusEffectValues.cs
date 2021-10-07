using System;
using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;
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

        public void LoadValues(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            //_heroStatusEffect.StatusEffectAsset = statusEffect;
            _heroStatusEffect.StatusEffectAsset = CloneStatusEffectAsset(statusEffectAsset);
            
            //StatusEffectAsset data
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffectAsset.UpdateTiming;
            _heroStatusEffect.StatusEffectInstance = statusEffectAsset.StatusEffectInstance;
            _heroStatusEffect.Name = statusEffectAsset.Name;
            _heroStatusEffect.Counters = statusEffectCounters;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
            
            //Other Data
            _heroStatusEffect.StatusEffectCasterHero = casterHero;
            _heroStatusEffect.StatusEffectTargetHero = targetHero;
            _heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
           
            //StatusEffectAsset References
            _heroStatusEffect.StatusEffectAsset.HeroStatusEffectReference = _heroStatusEffect;
           
            
            //TEST
            LoadStatusEffectComponentValues();

        }

        private IStatusEffectAsset CloneStatusEffectAsset(IStatusEffectAsset statusEffectAsset)
        {
            var statusEffectObject = statusEffectAsset as ScriptableObject;
            var statusEffectCloneObject = Instantiate(statusEffectObject);
            var statusEffectClone = statusEffectCloneObject as IStatusEffectAsset;
            
            //Re-assing reference to Scriptable Object Clone
            //TODO: Re-assign this to HeroStatus Effect
            statusEffectClone.CasterHero = statusEffectAsset.CasterHero;

            return statusEffectClone;
        }
        
        //TEST
        private void LoadStatusEffectComponentValues()
        {
            var statusEffectComponent = _heroStatusEffect.StatusEffectComponent;
            
            //Clone of status effect Asset
            statusEffectComponent.StatusEffectAsset = _heroStatusEffect.StatusEffectAsset;

            //Load Standard Actions
            foreach (var standardActionObject in _heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                var standardActionCloneObject = Instantiate(standardActionObject as ScriptableObject);
                statusEffectComponent.StandardActionObjectAssets.Add(standardActionCloneObject);
            }
        }




    }
}
