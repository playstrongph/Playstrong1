using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillDisabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillDisabled")]
    public class SkillDisabledAsset : SkillEnabledStatus
    {
        [SerializeField]
        private int silenceFactor = 1;
        
        public override void DisableSkill(ISkill skill)
        {
            //Increase Silence Factor
            skill.SkillLogic.SkillOtherAttributes.SilenceFactor += silenceFactor;
            Debug.Log(""+skill.SkillName +" Silence Factor: " +skill.SkillLogic.SkillOtherAttributes.SilenceFactor);
            
            //Set Skill Disabled
            var skillDisabled = skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled;
            skill.SkillLogic.SkillAttributes.SkillEnabledStatus = skillDisabled;

            //Unregister Skill
            skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            
            //Set Skill Not Ready
            skill.SkillLogic.UpdateSkillReadiness.SetSkillNotReady();
            
          
        }

        

        



    }
}
