using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillCooldown : MonoBehaviour, IUpdateSkillCooldown
    {
        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

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
        //Transferred to BasicAction
        /*public void SetCooldownValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            //Should pass to skillType first before eventually calling SetSkillCdToValue
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillType.SetSkillCdValue(_skillLogic, counter));
        }*/
      

       


    }
}
