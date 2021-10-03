using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillEnabled")]
    public class SkillEnabledAsset : Enums.SkillStatus.SkillEnabledStatus
    {
        
        //CD Passive Skill Should use this
        public override void EnableActiveSkill(ISkill skill)
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
            
            Debug.Log("Enable Active Skill: " +skill.SkillName);
        }

        public override void EnablePassiveSkill(ISkill skill)
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
            
            //Set Skill Ready
            //var skillReady = skill.SkillLogic.UpdateSkillReadiness.SkillReady;
            //skill.SkillLogic.SkillAttributes.SkillReadiness = skillReady;
            //skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);

            Debug.Log("Enable Passive Skill: " +skill.SkillName);
        }

        


    }
}
