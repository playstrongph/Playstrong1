
using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "SO's/Skill Type/Passive Skill")]
    public class PassiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }
        
        public override void ReduceSkillCd(ISkill skill, int counter)
        {
           //Do nothing for Passive Skills
        }
        
        public override void ResetSkillCd(ISkill skill)
        {
            //Do nothing for Passive Skills
        }
        
        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator DisablePassiveSkill(ISkill skill)
        {
          
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //var skillNotReady = skill.SkillLogic.UpdateSkillReadiness.SkillNotReady;
            //skill.SkillLogic.SkillAttributes.SkillReadiness = skillNotReady;
            //skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);
            //skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            
            //TEST
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled.DisableSkill(skill);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            /*var skillReady = skill.SkillLogic.UpdateSkillReadiness.SkillReady;
            if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
            {
                skill.SkillLogic.SkillAttributes.SkillReadiness = skillReady;
                skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);
            }
            skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(skill);
            Debug.Log("EnablePassive Skill , SkillType");*/
            
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled.EnableSkill(skill);

            logicTree.EndSequence();
            yield return null;
        }
    }
}
