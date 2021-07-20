using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusPassive", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status Passive")]
    public class SkillStatusPassiveAsset : SkillStatus
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
            
            //DisableDragSkillTarget
            _logicTree.AddCurrent(DisableDragSkillTarget());
            
            //DisableTargetVisual
            _logicTree.AddCurrent(DisableTargetVisual());


            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DisableDragSkillTarget()
        {   
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
        
        public override void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero)
        {
            // base.StartAction(skillAction, thisHero, targetHero);
            Debug.Log("Skill Status Passive Asset");
        }
        

    }
}
