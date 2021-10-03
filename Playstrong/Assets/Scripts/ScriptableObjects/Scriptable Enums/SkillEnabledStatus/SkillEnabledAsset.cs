using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "SO's/Scriptable Enums/SkillEnabledStatus/SkillEnabled")]
    public class SkillEnabledAsset : SkillEnabledStatus
    {
        [SerializeField]
        private int silenceFactor = 1;
        public override void EnableSkill(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            //Decrease Silence Factor
            skill.SkillLogic.SkillOtherAttributes.SilenceFactor -= silenceFactor;
            
            Debug.Log("Silence Factor: " +silenceFactor);
            
            Debug.Log(""+skill.SkillName +" Silence Factor: " +skill.SkillLogic.SkillOtherAttributes.SilenceFactor);
            
            //Check for other similar silence effects
            //if (skill.SkillLogic.SkillOtherAttributes.SilenceFactor <= 0)
               EnableAction(skill);
        }

        private void EnableAction(ISkill skill)
        {
            //var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            //Debug.Log(""+skill.SkillName +" Silence Factor: " +skill.SkillLogic.SkillOtherAttributes.SilenceFactor);
            
            if (skill.SkillLogic.SkillOtherAttributes.SilenceFactor <= 0)
            {
                //Set Skill Enabled
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
                
                Debug.Log("Skill Enabled");
            }
            
            //logicTree.EndSequence();
            //yield return null;
        }
    }
}
