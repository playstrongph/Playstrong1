using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillEnabled")]
    public class SkillEnabledAsset : SkillEnabledStatus
    {
         
        private int disableSkillFactor = 1;
        
        public override void EnableSkill(ISkill skill)
        {
            
            //Decrease Disable Skill Effects
            skill.SkillLogic.SkillOtherAttributes.DisableSkillEffects -= disableSkillFactor;
            
            if(skill.SkillLogic.SkillOtherAttributes.DisableSkillEffects <= 0)
                EnableSkillAction(skill);
        }
        
        /// <summary>
        /// Registers the skill again and updates the status.
        /// Checks if the skill is NOT the NoSkillCooldown type and has
        /// a cooldown of zero before setting it to SkillReady
        /// </summary>
        /// <param name="skill"></param>
        private void EnableSkillAction(ISkill skill)
        {
            //Register Skill Effect
            skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill);            
            skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill.Hero);
            
            //Set Skill Enabled
            var skillEnabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillEnabled;
            
            
            //Checks if the skill cooldown type is NOT NoSkillCooldown
            //if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
                //skill.SkillLogic.SkillAttributes.SkillCooldownType.SetSkillReady(skill);
            skill.SkillLogic.SkillAttributes.SkillCooldownType.UpdateSkillReadinessStatus(skill);

        }
        
        public override void SetSkillReady(ISkill skill)
        {
           skill.SkillLogic.UpdateSkillReadiness.SetSkillReady();
        }
        
        public override void SetSkillNotReady(ISkill skill)
        {
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
        }
        
        

        
    }
}
