using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusNotReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status NotReady")]
    public class SkillStatusNotReadyAsset : SkillStatus
    {

        private ISkillLogic _skillLogic;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private ITurnController _turnController;
        
        public override void StatusAction(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
            _logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            _turnController = _skillLogic.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            _logicTree.AddCurrent(SetSkillNotReady());
        }

        private IEnumerator SetSkillNotReady()
        {
            _logicTree.AddCurrent(DisableDragSkillTarget());
            _logicTree.AddCurrent(DisableTargetVisual());
            _visualTree.AddCurrent(VisualDisableSkillGlow());
            
            //TODO:
            
            
            //TEST
            _visualTree.AddCurrent(ShowCooldownText());

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DisableDragSkillTarget()
        {   
            _skillLogic.Skill.TargetSkill.GetSkillTargets.DisableGlows();
            _skillLogic.Skill.TargetSkill.DragSkillTarget.DisableDragSkillTarget();
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DisableTargetVisual()
        {
            
            _skillLogic.Skill.TargetSkill.SkillPreview.TargetVisual.TargetCanvas.gameObject.SetActive(false);
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualDisableSkillGlow()
        {
            var actionGlowFrame = _skillLogic.Skill.SkillVisual.SkillGlow;
            actionGlowFrame.SetActive(false);
            
            _visualTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ShowCooldownText()
        {
            var cooldownText = _skillLogic.Skill.SkillVisual.CooldownText;

            //TEST
            if(_skillLogic.SkillAttributes.Cooldown > 0)
                cooldownText.enabled = true;

            _visualTree.EndSequence();
            yield return null;
        }
        
        public override void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero)
        {
            //Don't perform default action
        }
        
        
        
        
        
      

    }
}
