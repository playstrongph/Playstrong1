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
            _heroStatusEffect.StatusEffectCounterUpdate = statusEffectAsset.UpdateTiming;
            _heroStatusEffect.StatusEffectInstance = statusEffectAsset.StatusEffectInstance;
            _heroStatusEffect.Name = statusEffectAsset.Name;
            _heroStatusEffect.Counters = statusEffectCounters;
            _heroStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _heroStatusEffect.StatusEffectCasterHero = casterHero;
            _heroStatusEffect.StatusEffectTargetHero = targetHero;
            _heroStatusEffect.CoroutineTreesAsset = targetHero.CoroutineTreesAsset;
            _heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
            
            //Create a unique HeroStatusEffect StatusEffectAsset
            _heroStatusEffect.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            CreateUniqueStandardActionsAndActionTargets(_heroStatusEffect);
            CreateUniqueBasicConditions(_heroStatusEffect);

            //TODO: Obsolete this later on
            //LoadStatusEffectComponentValues(statusEffectAsset,casterHero);
        }
        
        
        private void CreateUniqueStandardActionsAndActionTargets(IHeroStatusEffect heroStatusEffect)
        {
            var i = 0;
            foreach(var standardAction in heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                
                var standardActionClone = Instantiate(standardAction as ScriptableObject) as IStandardActionAsset;
                //Replace the standardActions in the statusEffectAsset with unique cloness
                heroStatusEffect.StatusEffectAsset.StandardActionsObjects[i] = standardActionClone as ScriptableObject;
                i++;
                
                //Create Basic Action Targets clone and set heroStatusEffectReference
                standardActionClone.BasicActionTargets = Instantiate(standardAction.BasicActionTargets as ScriptableObject) as IActionTargets;
                standardActionClone.BasicActionTargets.SetStatusEffectHero(_heroStatusEffect);
            }
        }
        
        private void CreateUniqueBasicConditions(IHeroStatusEffect heroStatusEffect)
        {
            foreach (var standardAction in heroStatusEffect.StatusEffectAsset.StandardActions)
            {
                var j = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    //TODO: SetStatusEffectReference
                    
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
        
        
        
        
        
        
        
        


        /*private void LoadStatusEffectComponentValues(IStatusEffectAsset statusEffectAsset,IHero casterHero)
        {
            var statusEffectComponent = _heroStatusEffect.StatusEffectComponent;

            //Create StatusComponent StatusEffectAsset and set references
            statusEffectComponent.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            statusEffectComponent.StatusEffectCasterHero = _heroStatusEffect.StatusEffectCasterHero;
            statusEffectComponent.StatusEffectTargetHero = _heroStatusEffect.StatusEffectTargetHero;
            
            //Create StatusEffectComponent StandardActions and set references
            //CreateStatusEffectComponentStandardActions(statusEffectComponent);

            //Create StatusEffectComponent BasicConditions and set references
            //CreateStatusEffectComponentBasicConditions(statusEffectComponent);
            
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
                //Note: This solved the need for references at asset level!
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
        */
        
        
       




    }
}
