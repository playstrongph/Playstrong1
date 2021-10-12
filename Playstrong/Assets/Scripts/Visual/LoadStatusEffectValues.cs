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
        
        private void LoadStatusEffectComponentValues(IStatusEffectAsset statusEffectAsset,IHero casterHero)
        {
            var statusEffectComponent = _heroStatusEffect.StatusEffectComponent;

            //Create StatusComponent StatusEffectAsset and set references
            statusEffectComponent.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            statusEffectComponent.StatusEffectAsset.HeroStatusEffectReference = _heroStatusEffect;
            statusEffectComponent.StatusEffectAsset.CasterHero = casterHero;
            
            //Set StatusEffect component references
            statusEffectComponent.StatusEffectCasterHero = _heroStatusEffect.StatusEffectCasterHero;
            statusEffectComponent.StatusEffectTargetHero = _heroStatusEffect.StatusEffectTargetHero;
            

            //Create StatusEffectComponent StandardActions and set references
            CreateStatusEffectComponentStandardActions(statusEffectComponent);

            //Create StatusEffectComponent BasicConditions and set references
            CreateStatusEffectComponentBasicConditions(statusEffectComponent);
            
            //TEST 
            //Assign Unique Status Effect Asset to HeroStatusEffect
            _heroStatusEffect.StatusEffectAsset = statusEffectComponent.StatusEffectAsset;
        }

        private void CreateStatusEffectComponentStandardActions(IStatusEffectComponent statusEffectComponent)
        {
            var i = 0;
            foreach(var standardActionObject in statusEffectComponent.StatusEffectAsset.StandardActions)
            {
                var standardActionCloneObject = Instantiate(standardActionObject as ScriptableObject);
                var basicActionTargetCloneObject = Instantiate(standardActionObject.BasicActionTargets as ScriptableObject);
                
                var standardActionClone = standardActionCloneObject as IStandardActionAsset;

                //Add Standard Actions And ActionTargets into StatusEffect Component
                statusEffectComponent.StandardActionObjectAssets.Add(standardActionCloneObject);
                statusEffectComponent.ActionTargetObjectAssets.Add(basicActionTargetCloneObject);
                
                //Set StatusEffect component standardActions' basicActionTarget 
                standardActionClone.BasicActionTargets = basicActionTargetCloneObject as IActionTargets;

                //Set standardActionClone BasicActionTargets statusEffectReference
                standardActionClone.BasicActionTargets.SetStatusEffectHero(_heroStatusEffect);

                //Load the StandardActions in the StatusEffect Component to the StatusEffectComponent StatusEffectAsset clone
                statusEffectComponent.StatusEffectAsset.StandardActionsObjects[i] = statusEffectComponent.StandardActionObjectAssets[i];
                i++;
            }
        }

        private void CreateStatusEffectComponentBasicConditions(IStatusEffectComponent statusEffectComponent)
        {
            foreach (var standardAction in statusEffectComponent.StandardActionAssets)
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
