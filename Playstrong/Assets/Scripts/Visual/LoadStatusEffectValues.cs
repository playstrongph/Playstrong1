using System;
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

        public void LoadValues(IStatusEffectAsset statusEffectAsset, int counters)
        {
            //_heroStatusEffect.StatusEffectAsset = statusEffect;
            _heroStatusEffect.StatusEffectAsset = CloneStatusEffectAsset(statusEffectAsset);
            _heroStatusEffect.StatusEffectAsset.HeroStatusEffectReference = _heroStatusEffect;
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffectAsset.UpdateTiming;
            
            _heroStatusEffect.StatusEffectInstance = statusEffectAsset.StatusEffectInstance;
            _heroStatusEffect.Name = statusEffectAsset.Name;
            _heroStatusEffect.Counters = counters;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
            
            //Re-assign reference
            _heroStatusEffect.CasterHero = statusEffectAsset.CasterHero;
            
            //TEST
            LoadStatusEffectComponentValues();

        }

        private IStatusEffectAsset CloneStatusEffectAsset(IStatusEffectAsset statusEffectAsset)
        {
            var statusEffectObject = statusEffectAsset as ScriptableObject;
            var statusEffectCloneObject = Instantiate(statusEffectObject);
            var statusEffectClone = statusEffectCloneObject as IStatusEffectAsset;
            
            //Re-assing reference to Scriptable Object Clone
            statusEffectClone.CasterHero = statusEffectAsset.CasterHero;

            return statusEffectClone;
        }
        
        //TEST
        private void LoadStatusEffectComponentValues()
        {
            var statusEffectComponent = _heroStatusEffect.StatusEffectComponent;
            
            //Clone of status effect Asset
            statusEffectComponent.StatusEffectAsset = _heroStatusEffect.StatusEffectAsset;

            //var statusEffectAsset = statusEffectComponent.StatusEffectAsset;

            foreach (var standardAction in _heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                var standardActionCloneObject = Instantiate(standardAction as ScriptableObject);
                statusEffectComponent.StandardActionObjectAssets.Add(standardActionCloneObject);
                
                //var standardActionClone = standardActionCloneObject as IStandardActionAsset;
                //statusEffectComponent.StandardActionAssets.Add(standardActionClone);
                
                Debug.Log("Standard Actions Count: " +statusEffectComponent.StandardActionAssets.Count);
                
            }

        }




    }
}
