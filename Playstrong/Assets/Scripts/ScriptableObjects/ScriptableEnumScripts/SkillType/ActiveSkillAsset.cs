using System.Collections;
using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.ScriptableEnumScripts.SkillType
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "SO's/Skill Type/Active Skill")]
    public class ActiveSkillAsset : Enums.SkillType.SkillType
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
        
        public override void ResetActiveSkillCd(ISkill skill)
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
        
        //NEW TEST - Nov 11 2021
        public override IEnumerator HeroUsingPassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //TEST Nov 12 - Do nothing
            //TODO: Transfer to DragSkillTarget
            //logicTree.AddCurrent(skill.Hero.HeroLogic.HeroStatus.HeroUsingSkill(skill));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator HeroUsedPassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //TEST Nov 12 - Do nothing
            //TODO: Transfer to DragSkillTarget
            //logicTree.AddCurrent(skill.Hero.HeroLogic.HeroStatus.HeroUsedSkillLastTurn(skill));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator HeroUsingActiveOrBasicSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //For Active and Basic skill
            skill.SkillLogic.UpdateSkillUseStatus.SetUsingSkill();

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator HeroUsedActiveOrBasicSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //For Active and Basic skill
            skill.SkillLogic.UpdateSkillUseStatus.SetUsedSkillLastTurn();

            logicTree.EndSequence();
            yield return null;
        }




    }
}
