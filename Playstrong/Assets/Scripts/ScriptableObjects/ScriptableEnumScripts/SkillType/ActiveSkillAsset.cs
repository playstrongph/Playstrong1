using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "SO's/Skill Type/Active Skill")]
    public class ActiveSkillAsset : SkillType
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
        
        public override void ResetSkillCd(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnResetCooldownToMax());
        }
        
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;

            logicTree.AddCurrent(EnableDragSkillTarget(skillLogic));
            logicTree.AddCurrent(EnableTargetVisual(skillLogic));
            visualTree.AddCurrent(VisualEnableSkillGlow(skillLogic));
            visualTree.AddCurrent(HideCooldownText(skillLogic));

            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator SetSkillNotReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            logicTree.AddCurrent(DisableDragSkillTarget(skillLogic));
            logicTree.AddCurrent(DisableTargetVisual(skillLogic));
            visualTree.AddCurrent(VisualDisableSkillGlow(skillLogic));
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
        
        public override IEnumerator DisableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled.DisableSkill(skill);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled.EnableSkill(skill);

            logicTree.EndSequence();
            yield return null;
        }




    }
}
