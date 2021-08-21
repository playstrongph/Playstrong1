using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;

namespace Logic
{
    public class ChangeSkillCooldown : MonoBehaviour, IChangeSkillCooldown
    {
        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }


        public IEnumerator ReduceCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            ReduceCd(counter);
            
            logicTree.EndSequence();
            yield return null;
            
        }

        private void ReduceCd(int counter)
        {
            var skillAttributes = _skillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd -= counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);

            skillAttributes.Cooldown = skillCd;
            _skillLogic.SkillReadiness.SetStatus(skillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
        }
        
        public IEnumerator IncreaseCooldown(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            IncreaseCd(counter);
            
            logicTree.EndSequence();
            yield return null;
            
        }

        private void IncreaseCd(int counter)
        {
            var skillAttributes = _skillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd += counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);

            skillAttributes.Cooldown = skillCd;
            _skillLogic.SkillReadiness.SetStatus(skillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
        }

        //Used by actions
        public void SetCooldownValue(int counter)
        {
            _skillLogic.SkillAttributes.SkillType.SetSkillCdValue(_skillLogic, counter);
        }

        //For Exclusive use by SkillType
        public IEnumerator SetSkillCdValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            SetCdValue(counter);
            
            logicTree.EndSequence();
            yield return null;
            
        }

        private void SetCdValue(int counter)
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;
            var skillCd = counter;
            
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);

            skillAttributes.Cooldown = skillCd;
            _skillLogic.SkillReadiness.SetStatus(skillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
        }
        
        public IEnumerator ResetCooldown()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            ResetCd();
            
            logicTree.EndSequence();
            yield return null;
        }

        private void ResetCd()
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillAttributes.Cooldown = maxSkillCd;  
            _skillLogic.SkillReadiness.SetStatus(maxSkillCd);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(maxSkillCd));
        }
        
        public IEnumerator RefreshCooldown()
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            RefreshCd();
            
            logicTree.EndSequence();
            yield return null;
        }

        private void RefreshCd()
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillAttributes.Cooldown = 0;  
            _skillLogic.SkillReadiness.SetStatus(0);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(0));
        }


        private IEnumerator VisualReduceCdAction(int skillCd)
        {
             var skillVisual = _skillLogic.Skill.SkillVisual;
             var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
             
             skillVisual.SkillCooldownVisual.UpdateCooldown(skillCd);
             
             visualTree.EndSequence();
             yield return null;
            
        }

       


    }
}
