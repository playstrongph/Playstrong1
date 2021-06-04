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
            //EnableDragSkillTarget
            _logicTree.AddCurrent(EnableDragSkillTarget());
            
            //EnablTargetVisuals
            _logicTree.AddCurrent(EnableTargetVisual());
            
            //TODO: Target Glows

            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator EnableDragSkillTarget()
        {   
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






    }
}
