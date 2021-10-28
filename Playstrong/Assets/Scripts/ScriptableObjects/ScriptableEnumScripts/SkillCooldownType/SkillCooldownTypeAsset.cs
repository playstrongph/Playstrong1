using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.ScriptableEnumScripts.SkillCooldownType
{
    public class SkillCooldownTypeAsset : ScriptableObject, ISkillCooldownTypeAsset
    {
        public virtual IEnumerator TurnReduceCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd -= counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(skill);
            visualTree.AddCurrent(VisualReduceCdAction(skill,skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator IncreaseCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;     
            var skillCd = skillAttributes.Cooldown;
            var maxSkillCd = skillAttributes.BaseCooldown;

            skillCd += counter;
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(skill);
            
            visualTree.AddCurrent(VisualReduceCdAction(skill,skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //Used By Refresh and Reset Basic Actions
        public virtual IEnumerator SetSkillCdToValue(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;
            var skillCd = counter;
            
            skillCd = Mathf.Clamp(skillCd,0, maxSkillCd);
            skillAttributes.Cooldown = skillCd;

            UpdateSkillReadinessStatus(skill);
            visualTree.AddCurrent(VisualReduceCdAction(skill,skillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator TurnResetCooldownToMax(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCd = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = maxSkillCd;  
            
            UpdateSkillReadinessStatus(skill);
            visualTree.AddCurrent(VisualReduceCdAction(skill, maxSkillCd));
            
            logicTree.EndSequence();
            yield return null;
        }

        public virtual IEnumerator RefreshCooldownToZero(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            
            skillAttributes.Cooldown = 0;
            
            UpdateSkillReadinessStatus(skill);
            
            visualTree.AddCurrent(VisualReduceCdAction(skill,0));
            
            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Checks if skill is enabled and has a cooldown of zero
        /// before setting it to skill ready
        /// </summary>
        /// <param name="skill"></param>
        public virtual void UpdateSkillReadinessStatus(ISkill skill)
        {
            var skillCooldown = skill.SkillLogic.SkillAttributes.Cooldown;
            
            if(skillCooldown<=0)
                skill.SkillLogic.SkillAttributes.SkillEnabledStatus.SetSkillReady(skill);
                
            else
                skill.SkillLogic.SkillAttributes.SkillEnabledStatus.SetSkillNotReady(skill);
        }
        
        
        private IEnumerator VisualReduceCdAction(ISkill skill,int skillCd)
        {
             var skillVisual = skill.SkillVisual;
             var visualTree = skill.CoroutineTreesAsset.MainVisualTree;
             
             skillVisual.SkillCooldownVisual.UpdateCooldown(skillCd);
             
             visualTree.EndSequence();
             yield return null;
            
        }
      
      

       


    }
}
