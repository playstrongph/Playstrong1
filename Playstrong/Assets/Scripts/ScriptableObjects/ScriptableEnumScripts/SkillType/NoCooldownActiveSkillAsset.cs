using System.Collections;
using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.ScriptableEnumScripts.SkillType
{
    
    /// <summary>
    /// Used by Fighting Spirit Skills
    /// Cooldown should be set to 999 
    /// </summary>
    [CreateAssetMenu(fileName = "NoCdActiveSkill", menuName = "SO's/Skill Type/NoCdActiveSkill")]
    public class NoCooldownActiveSkillAsset : Enums.SkillType.SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }

        public override void ReduceSkillCd(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //Removed since there is No Cooldown
            //logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnReduceCooldown(counter));
        }
        
        public override void ResetSkillCd(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //Removed since there is No Cooldown
            //logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnResetCooldownToMax());
        }
        
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;

            logicTree.AddCurrent(EnableDragSkillTarget(skillLogic));
            logicTree.AddCurrent(EnableTargetVisual(skillLogic));
            visualTree.AddCurrent(VisualEnableSkillGlow(skillLogic));
            
            //Removed since there is No Cooldown
            //visualTree.AddCurrent(HideCooldownText(skillLogic));

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
            
            //Removed since there is NO cooldown
            //visualTree.AddCurrent(ShowCooldownText(skillLogic));
            
            logicTree.EndSequence();
            yield return null;
        }


        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            //Removed since there is No Cooldown
            //logicTree.AddCurrent(skillLogic.UpdateSkillCooldown.SetSkillCdToValue(counter));

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
