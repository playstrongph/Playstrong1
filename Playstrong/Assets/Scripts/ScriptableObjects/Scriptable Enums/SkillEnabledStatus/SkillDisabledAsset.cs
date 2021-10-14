using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillDisabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillDisabled")]
    public class SkillDisabledAsset : SkillEnabledStatus
    {
        private int disableSkillFactor = 1;
        
        public override void DisableSkill(ISkill skill)
        {
            //Increase Disable Skill Effects
            skill.SkillLogic.SkillOtherAttributes.DisableSkillEffects += disableSkillFactor;
            
            //Set Skill Disabled
            var skillDisabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillDisabled;

            //Set Skill Not Ready
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
            
            //Unregister Skill
            skill.SkillLogic.SkillAttributes.SkillEffectAsset.UnregisterSkillEffect(skill);
            
          
        }

        

        



    }
}
