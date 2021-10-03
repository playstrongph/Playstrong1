using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillEnabled")]
    public class SkillEnabledAsset : SkillEnabledStatus
    {
        public override void EnableSkill(ISkill skill)
        {
            
            var skillEnabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillEnabled;
            
            //Set Skill Ready
            var skillReady = skill.SkillLogic.UpdateSkillReadiness.SkillReady;
            if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
            {
                skill.SkillLogic.SkillAttributes.SkillReadiness = skillReady;
                skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);
            }
            
            //Register Skill Effect
            skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(skill);
            
            Debug.Log("Enable Skill: " +skill.SkillName);
        }
    }
}
