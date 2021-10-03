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
            
            //TODO: Localize this
            //_skillLogic.UpdateSkillReadiness.SetStatusBasedOnSkillCooldown(skillCd);
            
            //TEST
            UpdateSkillReadinessStatus(_skillLogic);

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
            
            //TODO: Localize
            //_skillLogic.UpdateSkillReadiness.SetStatusBasedOnSkillCooldown(skillCd);
            
            //TEST
            UpdateSkillReadinessStatus(_skillLogic);

            var visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(VisualReduceCdAction(skillCd));
        }

        //Used by actions
        public void SetCooldownValue(int counter)
        {
            var logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(_skillLogic.SkillAttributes.SkillType.SetSkillCdValue(_skillLogic, counter));
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
            
            //TODO: Localize
            //_skillLogic.UpdateSkillReadiness.SetStatusBasedOnSkillCooldown(skillCd);
            //TEST
            UpdateSkillReadinessStatus(_skillLogic);

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
            
            //TODO: Localize
            //_skillLogic.UpdateSkillReadiness.SetStatusBasedOnSkillCooldown(maxSkillCd);
            
            //TEST
            UpdateSkillReadinessStatus(_skillLogic);

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
            
            //TODO: Localize
            //_skillLogic.UpdateSkillReadiness.SetStatusBasedOnSkillCooldown(0);
            
            //TEST
            UpdateSkillReadinessStatus(_skillLogic);

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

        private void UpdateSkillReadinessStatus(ISkillLogic skillLogic)
        {
            var skillCooldown = skillLogic.SkillAttributes.Cooldown;
            
            if(skillCooldown<=0)
                skillLogic.UpdateSkillReadiness.SetSkillReady();
            else
                skillLogic.UpdateSkillReadiness.SetSkillNotReady();
        }

       


    }
}
