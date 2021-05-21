using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroStatus
{
    [CreateAssetMenu(fileName = "HeroInactive", menuName = "SO's/HeroStatus/HeroInactive")]
    public class HeroInactiveAsset : ScriptableObject, IHeroStatusAsset, IHeroInactiveAsset
    {
    
        private ITurnController _turnController;
        private IHeroLogic _heroLogic;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;    
        
        public void InitializeTurnController(ITurnController turnController)
        {
            _turnController = turnController;
        }

        public void StatusAction(IHeroLogic heroLogic)
        {
            _heroLogic = heroLogic;
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
            
            _logicTree.AddCurrent(SetInactive());
            
        }

        private IEnumerator SetInactive()
        {
            
            _logicTree.AddCurrent(DisableTargetHeroPreview());
            _logicTree.AddCurrent(DisableDragHeroAttack());
            
            _visualTree.AddCurrent(VisualDisableActionHeroGlow());
            _visualTree.AddCurrent(VisualDisableHeroPortrait());
            _visualTree.AddCurrent(VisualDisableHeroSkills());
            
            
            yield return null;
            _logicTree.EndSequence();
            
        }
        
        private IEnumerator DisableDragHeroAttack()
        {
            _heroLogic.Hero.TargetHero.GetAttackTargets.DisableGlows();
            
            yield return null;
            _logicTree.EndSequence();
        }
        
        private IEnumerator DisableTargetHeroPreview()
        {
            _heroLogic.Hero.TargetHero.HeroPreview.TargetVisual.TargetCanvas.gameObject.SetActive(false);
            
            yield return null;
            _logicTree.EndSequence();
        }
        
        private IEnumerator VisualDisableActionHeroGlow()
        {
            var actionGlowFrame = _heroLogic.Hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            actionGlowFrame.SetActive(false);

            yield return null;
            _visualTree.EndSequence();
        }
        
        private IEnumerator VisualDisableHeroPortrait()
        {
            var heroPortrait = _heroLogic.Hero.HeroPortrait;
            heroPortrait.Portrait.SetActive(false);
           
            
            yield return null;
            _visualTree.EndSequence();
        }
        
        private IEnumerator VisualDisableHeroSkills()
        {
            var heroSkills = _heroLogic.Hero.Skills;
            heroSkills.Skills.SetActive(false);
            
            yield return null;
            _visualTree.EndSequence();
        }



    }
}
