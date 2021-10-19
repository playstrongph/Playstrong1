using System;
using Interfaces;
using Logic;
using ScriptableObjects.SkillEffects;
using ScriptableObjects.StandardActions;
using TMPro.EditorUtilities;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
       
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void InitializeSkillAttributes(IHeroSkillAsset skillAsset)
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            
            skillAttributes.Cooldown = skillAsset.BaseCooldown;
            skillAttributes.BaseCooldown = skillAsset.BaseCooldown;
            skillAttributes.SkillType = skillAsset.SkillType;
            skillAttributes.SkillTarget = skillAsset.SkillTarget;
            skillAttributes.SkillReadiness = skillAsset.SkillReadiness;
            
            //Initializations
            skillAttributes.SkillReference = _skillLogic.Skill;
           _skillLogic.UpdateSkillUseStatus.SetNotUsingSkillStatus();
            
            CreateUniqueSkillEffectAsset(skillAsset);

        }
        
        //TEST
        private void CreateUniqueSkillEffectAsset(IHeroSkillAsset skillAsset)
        {
            _skillLogic.SkillAttributes.SkillEffectAsset = Instantiate(skillAsset.SkillEffect as ScriptableObject) as ISkillEffectAsset;
            
            CreateUniqueStandardActionsAndActionTargets();
            CreateUniqueBasicConditions();
        }
        
        private void CreateUniqueStandardActionsAndActionTargets()
        {
            var i = 0;
            foreach(var standardAction in  _skillLogic.SkillAttributes.SkillEffectAsset.StandardActions)
            {
                
                var standardActionClone = Instantiate(standardAction as ScriptableObject) as IStandardActionAsset;
                //Replace the standardActions in the statusEffectAsset with unique cloness
                _skillLogic.SkillAttributes.SkillEffectAsset.StandardActionsObjects[i] = standardActionClone as ScriptableObject;
                i++;
                
                //Create Basic Action Targets clone and set heroStatusEffectReference
                standardActionClone.BasicActionTargets = Instantiate(standardAction.BasicActionTargets as ScriptableObject) as IActionTargets;
                //TODO: Check if there will be a need for the BasicActionTarget to Reference the Skill
                standardActionClone.BasicActionTargets.SetSkillReference(_skillLogic.Skill);
                
                //TEST - Create EventSubscribers
                standardActionClone.EventSubscribers = Instantiate(standardAction.EventSubscribers as ScriptableObject) as IActionTargets;
                standardActionClone.EventSubscribers.SetSkillReference(_skillLogic.Skill);
            }
        }
        
        private void CreateUniqueBasicConditions()
        {
            foreach (var standardAction in _skillLogic.SkillAttributes.SkillEffectAsset.StandardActions)
            {
                var j = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.OrBasicConditionsObjects[j] = basicConditionCloneObject;
                    j++;
                    
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    basicConditionClone.SkillReference = _skillLogic.Skill;
                }

                var k = 0;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.AndBasicConditionsObjects[k] = basicConditionCloneObject;
                    k++;
                    
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    basicConditionClone.SkillReference = _skillLogic.Skill;
                }
            }
        }
        
        
        
        
        
        


    }
}
