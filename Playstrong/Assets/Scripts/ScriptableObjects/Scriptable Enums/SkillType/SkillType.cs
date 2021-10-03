using System.Collections;
using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    public class SkillType : ScriptableObject, ISkillType
    {
        public virtual void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            //set cooldown.enabled status
        }

        public virtual void ReduceSkillCd(ISkill skill, int counter)
        {
            //No action for Passive Skills
            //ReduceCd for Active Skills
            //ReduceCD for CdPassiveSkills
        }

        public virtual void ResetSkillCd(ISkill skill)
        {
            //No action for Passive Skills
            //Max Cooldown for Active Skills
            //Max Cooldown for CdPassive Skills
        }
        
        
        //For CD Passive and Active skills
        public virtual IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;


            logicTree.EndSequence();
            yield return null;
        }
        
        //For CD Passive and Active skills
        public virtual IEnumerator SetSkillNotReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }


        public virtual IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST SILENCE and SEAL
        public virtual IEnumerator DisableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator EnableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator DisablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //Skill Ready Actions
        protected IEnumerator EnableDragSkillTarget(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            skillLogic.Skill.TargetSkill.GetSkillTargets.EnableGlows();
            skillLogic.Skill.TargetSkill.DragSkillTarget.EnableDragSkillTarget();
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator EnableTargetVisual(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainLogicTree;
            skillLogic.Skill.TargetSkill.SkillPreview.TargetVisual.TargetCanvas.gameObject.SetActive(true);
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator VisualEnableSkillGlow(ISkillLogic skillLogic)
        {
            var visualTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainVisualTree;
            
            var actionGlowFrame = skillLogic.Skill.SkillVisual.SkillGlow;
            actionGlowFrame.SetActive(true);
            
            visualTree.EndSequence();
            yield return null;
        }
        protected IEnumerator HideCooldownText(ISkillLogic skillLogic)
        {
            var visualTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainVisualTree;
            var cooldownText = skillLogic.Skill.SkillVisual.CooldownText;

            cooldownText.enabled = false;
            
            visualTree.EndSequence();
            yield return null;
        }
        
        //Skill Not Ready Actions
        protected IEnumerator DisableDragSkillTarget(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            skillLogic.Skill.TargetSkill.GetSkillTargets.DisableGlows();
            skillLogic.Skill.TargetSkill.DragSkillTarget.DisableDragSkillTarget();
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator DisableTargetVisual(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            skillLogic.Skill.TargetSkill.SkillPreview.TargetVisual.TargetCanvas.gameObject.SetActive(false);
            
            logicTree.EndSequence();
            yield return null;
        }
        protected IEnumerator VisualDisableSkillGlow(ISkillLogic skillLogic)
        {
            var actionGlowFrame = skillLogic.Skill.SkillVisual.SkillGlow;
            var visualTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainVisualTree;
            
            actionGlowFrame.SetActive(false);
            
            visualTree.EndSequence();
            yield return null;
        }
        protected IEnumerator ShowCooldownText(ISkillLogic skillLogic)
        {
            var cooldownText = skillLogic.Skill.SkillVisual.CooldownText;
            var visualTree = skillLogic.Skill.Hero.CoroutineTreesAsset.MainVisualTree;

            //Display value when skill is in cooldown
            if(skillLogic.SkillAttributes.Cooldown > 0)
                cooldownText.enabled = true;

            visualTree.EndSequence();
            yield return null;
        }
        



    }
}
