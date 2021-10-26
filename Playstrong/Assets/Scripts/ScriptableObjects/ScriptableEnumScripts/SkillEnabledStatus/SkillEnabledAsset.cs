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
        
        private void EnableSkillAction(ISkill skill)
        {
            //Register Skill Effect
            skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill);            
            skill.SkillLogic.SkillAttributes.SkillEffectAsset.RegisterSkillEffect(skill.Hero);
            
            
            //Set Skill Ready
            if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
                skill.SkillLogic.UpdateSkillReadiness.SetSkillReady();
            
            
            //Set Skill Enabled
            var skillEnabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillEnabled;

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
