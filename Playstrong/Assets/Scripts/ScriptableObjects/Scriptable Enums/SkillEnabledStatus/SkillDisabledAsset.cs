using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillDisabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillDisabled")]
    public class SkillDisabledAsset : Enums.SkillStatus.SkillEnabledStatus
    {
        public override void DisableActiveSkill(ISkill skill)
        {
            var skillDisabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillDisabled;
            
            //Unregister Skill
            skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            
            //Set Skill Not Ready
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
            
            Debug.Log("Disable Active Skill: " +skill.SkillName);
            
        }

        public override void DisablePassiveSkill(ISkill skill)
        {
            var skillDisabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillDisabled;
            
            //Unregister Skill
            skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            
            //Set Skill Not Ready
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
            
            Debug.Log("Disable Passive Skill: " +skill.SkillName);
        }

        



    }
}
