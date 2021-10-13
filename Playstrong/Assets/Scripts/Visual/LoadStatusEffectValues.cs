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
            //Set HeroStatusEffect data
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            _heroStatusEffect.StatusEffectUpdateTiming = statusEffectAsset.UpdateTiming;
            _heroStatusEffect.StatusEffectInstance = statusEffectAsset.StatusEffectInstance;
            _heroStatusEffect.Name = statusEffectAsset.Name;
            _heroStatusEffect.Counters = statusEffectCounters;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _heroStatusEffect.StatusEffectCasterHero = casterHero;
            _heroStatusEffect.StatusEffectTargetHero = targetHero;
            _heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
            
            //Unique StatusEffectAsset
            CreateUniqueStatusEffectAsset(statusEffectAsset);
        }

        private void CreateUniqueStatusEffectAsset(IStatusEffectAsset statusEffectAsset)
        {
            _heroStatusEffect.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            CreateUniqueStandardActionsAndActionTargets();
            CreateUniqueBasicConditions();
        }
        private void CreateUniqueStandardActionsAndActionTargets()
        {
            var i = 0;
            foreach(var standardAction in _heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                
                var standardActionClone = Instantiate(standardAction as ScriptableObject) as IStandardActionAsset;
                //Replace the standardActions in the statusEffectAsset with unique cloness
                _heroStatusEffect.StatusEffectAsset.StandardActionsObjects[i] = standardActionClone as ScriptableObject;
                i++;
                
                //Create Basic Action Targets clone and set heroStatusEffectReference
                standardActionClone.BasicActionTargets = Instantiate(standardAction.BasicActionTargets as ScriptableObject) as IActionTargets;
                standardActionClone.BasicActionTargets.SetStatusEffectHero(_heroStatusEffect);
            }
        }
        private void CreateUniqueBasicConditions()
        {
            foreach (var standardAction in _heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                var j = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.OrBasicConditionsObjects[j] = basicConditionCloneObject;
                    j++;
                    
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    basicConditionClone.StatusEffectReference = _heroStatusEffect;
                }

                var k = 0;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.AndBasicConditionsObjects[k] = basicConditionCloneObject;
                    k++;
                    
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    basicConditionClone.StatusEffectReference = _heroStatusEffect;
                }
            }
        }

    }
}
