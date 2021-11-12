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
            
            logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnReduceCooldown(counter));
        }
        
        //Reset when skill cooldown = 0, i.e. SkillReadyStatus
        public override void ResetActiveSkillCd(ISkill skill)
        {
            //var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnResetCooldownToMax());
            
            //TODO: Create own reset for CDPassiveSkill
        }
        
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            
            visualTree.AddCurrent(HideCooldownText(skillLogic));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator SetSkillNotReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            visualTree.AddCurrent(ShowCooldownText(skillLogic));

            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skillLogic.UpdateSkillCooldown.SetSkillCdToValue(counter));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator DisablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled.DisableSkill(skill);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled.EnableSkill(skill);

            logicTree.EndSequence();
            yield return null;
        }

    }
}
