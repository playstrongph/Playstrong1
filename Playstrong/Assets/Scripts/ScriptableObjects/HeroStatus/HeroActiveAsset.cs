using System;
using System.Collections;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.HeroStatus
{
    [CreateAssetMenu(fileName = "HeroActive", menuName = "SO's/HeroStatus/HeroActive")]
    public class HeroActiveAsset : ScriptableObject, IHeroActiveAsset, IHeroStatusAsset
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

            _logicTree.AddCurrent(SetActive());
        }

        private IEnumerator SetActive()
        {
           _heroLogic.HeroTimer.ResetHeroTimer();
            
            _logicTree.AddCurrent(EnableTargetHeroPreview());
            _logicTree.AddCurrent(EnableDragHeroAttack());
            
            
            _visualTree.AddCurrent(VisualEnableActionHeroGlow());
            _visualTree.AddCurrent(VisualEnableHeroPortrait());
            _visualTree.AddCurrent(VisualEnableHeroSkills());
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator EnableDragHeroAttack()
        {
           
           _heroLogic.Hero.TargetHero.GetAttackTargets.EnableGlows();
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator EnableTargetHeroPreview()
        {
            _heroLogic.Hero.TargetHero.HeroPreview.TargetVisual.TargetCanvas.gameObject.SetActive(true);
            
             yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator VisualEnableActionHeroGlow()
        {
            var actionGlowFrame = _heroLogic.Hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            actionGlowFrame.SetActive(true);

            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualEnableHeroPortrait()
        {
            var heroPortrait = _heroLogic.Hero.HeroPortrait;
            heroPortrait.Portrait.SetActive(true);
           
            
            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualEnableHeroSkills()
        {
            var heroSkills = _heroLogic.Hero.Skills;
            heroSkills.Skills.SetActive(true);
            
            yield return null;
            _visualTree.EndSequence();
        }


        
        
        


    }
}
