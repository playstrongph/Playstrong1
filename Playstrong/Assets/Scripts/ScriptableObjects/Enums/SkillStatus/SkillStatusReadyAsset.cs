using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status Ready")]
    public class SkillStatusReadyAsset : ScriptableObject, ISkillStatus
    {

        private ISkillLogic _skillLogic;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        private ITurnController _turnController;

        public void StatusAction(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
            _logicTree = _skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            _turnController = _skillLogic.Skill.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
           _logicTree.AddCurrent(SetSkillReady());
        }

        private IEnumerator SetSkillReady()
        {
           
            _logicTree.AddCurrent(EnableDragSkillTarget());
            _logicTree.AddCurrent(EnableTargetVisual());
            
            _visualTree.AddCurrent(VisualEnableSkillGlow());

            _logicTree.EndSequence();
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






    }
}
