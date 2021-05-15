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

            _visualTree.AddCurrent(VisualActionHeroGlow());
            _visualTree.AddCurrent(VisualHeroPortrait());
            _visualTree.AddCurrent(VisualHeroSkills());
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator VisualActionHeroGlow()
        {
            var actionGlowFrame = _heroLogic.Hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            actionGlowFrame.SetActive(true);

            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualHeroPortrait()
        {
            var heroPortrait = _heroLogic.Hero.HeroPortrait;
            heroPortrait.Portrait.SetActive(true);
           
            
            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualHeroSkills()
        {
            var heroSkills = _heroLogic.Hero.Skills;
            heroSkills.Skills.SetActive(true);
            
            yield return null;
            _visualTree.EndSequence();
        }


        
        
        


    }
}
