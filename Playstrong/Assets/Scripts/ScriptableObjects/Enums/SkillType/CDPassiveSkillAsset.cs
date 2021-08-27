using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "CDPassiveSkill", menuName = "SO's/Skill Type/CDPassiveSkill")]
    public class CdPassiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

        public override void ReduceSkillCd(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ReduceCooldown(counter));
        }
        
        //Reset when skill cooldown = 0, i.e. SkillReadyStatus
        public override void ResetSkillCd(ISkill skill)
        {
            skill.SkillLogic.SkillAttributes.SkillStatus.ResetSkillCooldown(skill);
        }
        
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillReady = skillLogic.SkillAttributes.SkillStatus;
            
            logicTree.AddCurrent(skillReady.SetCdPassiveSkillReady(skillLogic));
            

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skillLogic.ChangeSkillCooldown.SetSkillCdValue(counter));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator DisablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var skillNotReady = skill.SkillLogic.SkillReadiness.SkillNotReady;

            skill.SkillLogic.SkillAttributes.SkillStatus = skillNotReady;
            skill.SkillLogic.SkillAttributes.SkillStatus.StatusAction(skill.SkillLogic);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var skillReady = skill.SkillLogic.SkillReadiness.SkillReady;

            if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
            {
                skill.SkillLogic.SkillAttributes.SkillStatus = skillReady;
                skill.SkillLogic.SkillAttributes.SkillStatus.StatusAction(skill.SkillLogic);
            }

            logicTree.EndSequence();
            yield return null;
        }

    }
}
