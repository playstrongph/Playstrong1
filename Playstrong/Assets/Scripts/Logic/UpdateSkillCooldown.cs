using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillCooldown : MonoBehaviour, IUpdateSkillCooldown
    {
        private ISkillLogic _skillLogic;
        private ISkill _skill;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            _skill = _skillLogic.Skill;
        }

        public IEnumerator ReduceCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.ReduceCooldown(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator IncreaseCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.IncreaseCooldown(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator SetSkillCdToValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.SetSkillCdToValue(_skill, counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator ResetCooldownToMax()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.ResetCooldownToMax(_skill));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator RefreshCooldownToZero()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillCooldownType.RefreshCooldownToZero(_skill));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        //BackUp
        
         /*
         public IEnumerator ReduceCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            var skillAttributes = _skillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd -= counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(_skillLogic);
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator IncreaseCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = _skillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd += counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(_skillLogic);
            
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator SetSkillCdToValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;
            var skillCd = counter;
            
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(_skillLogic);
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator ResetCooldownToMax()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = maxSkillCd;  
            
            UpdateSkillReadinessStatus(_skillLogic);
            visualTree.AddCurrent(VisualReduceCdAction(maxSkillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator RefreshCooldownToZero()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = _skillLogic.SkillAttributes;
            
            skillAttributes.Cooldown = 0;
            
            UpdateSkillReadinessStatus(_skillLogic);
            visualTree.AddCurrent(VisualReduceCdAction(0));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //AUXILIARY METHODS
        private void UpdateSkillReadinessStatus(ISkillLogic skillLogic)
        {
            var skillCooldown = skillLogic.SkillAttributes.Cooldown;
            
            if(skillCooldown<=0)
                //skillLogic.UpdateSkillReadiness.SetSkillReady();
                skillLogic.SkillAttributes.SkillEnabledStatus.SetSkillReady(skillLogic.Skill);
                
            else
                //skillLogic.UpdateSkillReadiness.SetSkillNotReady();
                skillLogic.SkillAttributes.SkillEnabledStatus.SetSkillNotReady(skillLogic.Skill);
        }
        private IEnumerator VisualReduceCdAction(int skillCd)
        {
             var skillVisual = _skillLogic.Skill.SkillVisual;
             var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
             
             skillVisual.SkillCooldownVisual.UpdateCooldown(skillCd);
             
             visualTree.EndSequence();
             yield return null;
            
        }
        */
       
      

       


    }
}
