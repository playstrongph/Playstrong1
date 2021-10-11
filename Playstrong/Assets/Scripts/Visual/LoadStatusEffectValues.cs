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
            //Update the statusEffect asset to a unique instance
            _heroStatusEffect.StatusEffectAsset = CloneStatusEffectAsset(statusEffectAsset);
            
            //StatusEffectAsset data
            _heroStatusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffectAsset.UpdateTiming;
            _heroStatusEffect.StatusEffectInstance = statusEffectAsset.StatusEffectInstance;
            _heroStatusEffect.Name = statusEffectAsset.Name;
            _heroStatusEffect.Counters = statusEffectCounters;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;

            //Other Data
            _heroStatusEffect.StatusEffectCasterHero = casterHero;
            _heroStatusEffect.StatusEffectTargetHero = targetHero;
            _heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();

            //TEST
            LoadStatusEffectComponentValues(statusEffectAsset,casterHero);
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
        
        //TEST - Create Own File if required
        private void LoadStatusEffectComponentValues(IStatusEffectAsset statusEffectAsset,IHero casterHero)
        {
            var statusEffectComponent = _heroStatusEffect.StatusEffectComponent;

            //Clone of StatusEffectAsset
            statusEffectComponent.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            
            //StatusEffectAsset References
            statusEffectComponent.StatusEffectAsset.HeroStatusEffectReference = _heroStatusEffect;
            statusEffectComponent.StatusEffectAsset.CasterHero = casterHero;

            var i = 0;
            //Load Standard Actions
            foreach(var standardActionObject in _heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                var standardActionCloneObject = Instantiate(standardActionObject as ScriptableObject);
                var actionTarget = Instantiate(standardActionObject.BasicActionTargets as ScriptableObject);
                var standardActionClone = standardActionCloneObject as IStandardActionAsset;


                statusEffectComponent.StandardActionObjectAssets.Add(standardActionCloneObject);
                statusEffectComponent.ActionTargetObjectAssets.Add(actionTarget);
                standardActionClone.BasicActionTargets = actionTarget as IActionTargets;

                //Set standardActionClone BasicActionTargets statusEffectReference
                standardActionClone.BasicActionTargets.SetStatusEffectHero(_heroStatusEffect);

                //Load the StandardActions in the StatusEffect Component to the StatusEffectComponent Asset
                statusEffectComponent.StatusEffectAsset.StandardActionsObjects[i] = statusEffectComponent.StandardActionObjectAssets[i];
                i++;
            }
            
            //TODO Separate Method Call
            foreach (var standardAction in _heroStatusEffect.StatusEffectComponent.StandardActionAssets)
            {
                var j = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.OrBasicConditionsObjects[j] = basicConditionCloneObject;
                    j++;
                }

                var k = 0;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.AndBasicConditionsObjects[k] = basicConditionCloneObject;
                    k++;
                }
            }
        }




    }
}
