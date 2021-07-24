using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status Ready")]
    public class SkillStatusReadyAsset : SkillStatus
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
            var skillType = skillLogic.SkillAttributes.SkillType;

            _logicTree.AddCurrent(skillType.SetSkillReady(skillLogic));
        }
        
        //TODO: Only for active skill type
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            logicTree.AddCurrent(EnableDragSkillTarget());
            logicTree.AddCurrent(EnableTargetVisual());
            visualTree.AddCurrent(VisualEnableSkillGlow());

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator EnableDragSkillTarget()
        {   
            _skillLogic.Skill.TargetSkill.GetSkillTargets.EnableGlows();
            _skillLogic.Skill.TargetSkill.DragSkillTarget.EnableDragSkillTarget();
            
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator EnableTargetVisual()
        {
            
            _skillLogic.Skill.TargetSkill.SkillPreview.TargetVisual.TargetCanvas.gameObject.SetActive(true);
            
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator VisualEnableSkillGlow()
        {
            var actionGlowFrame = _skillLogic.Skill.SkillVisual.SkillGlow;
            actionGlowFrame.SetActive(true);
            
            _visualTree.EndSequence();
            yield return null;
        }

        public override void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero)
        {
           base.StartAction(skillAction, thisHero, targetHero);
       
        }
        
        public override void ResetSkillCooldown(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ResetCooldown());

        }
    }
}
