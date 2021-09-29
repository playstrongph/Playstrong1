using System;
using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Others;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjects.HeroStatus
{
    [CreateAssetMenu(fileName = "HeroActive", menuName = "SO's/HeroStatus/HeroActive")]
    public class HeroActiveAsset : HeroStatusAsset
    {

        private ITurnController _turnController;
        private IHeroLogic _heroLogic;
        
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        public override void InitializeTurnController(ITurnController turnController)
        {
            _turnController = turnController;
        }
        
        public override void StatusAction(IHeroLogic heroLogic)
        {
            _heroLogic = heroLogic;
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;

            _logicTree.AddCurrent(SetActive());
        }

        /*public override IEnumerator EndHeroTurn(IHeroLogic heroLogic)
        {
            var logicTree = heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var turnController = heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            
            turnController.EndCombatTurn();

            logicTree.EndSequence();
            yield return null;
        }*/

        private IEnumerator SetActive()
        {
            //_heroLogic.HeroTimer.ResetHeroTimer();
            
            _logicTree.AddCurrent(EnableTargetHeroPreview());
            _logicTree.AddCurrent(EnableDragHeroAttack());

            _visualTree.AddCurrent(VisualEnableActionHeroGlow());
            _visualTree.AddCurrent(VisualEnableHeroPortrait());
            _visualTree.AddCurrent(VisualEnableHeroSkills());

            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator EnableDragHeroAttack()
        {
           
           _heroLogic.Hero.TargetHero.GetAttackTargets.EnableGlows();
           _heroLogic.Hero.TargetHero.DragHeroAttack.EnableDragHeroAttack();

           _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator EnableTargetHeroPreview()
        {
            _heroLogic.Hero.TargetHero.HeroPreview.TargetVisual.TargetCanvas.gameObject.SetActive(true);
            
             
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator VisualEnableActionHeroGlow()
        {
            var actionGlowFrame = _heroLogic.Hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            actionGlowFrame.SetActive(true);
            
            _visualTree.EndSequence();
            yield return null;
        }

        private IEnumerator VisualEnableHeroPortrait()
        {
            var heroPortrait = _heroLogic.Hero.HeroPortrait;
            heroPortrait.Portrait.SetActive(true);

            _visualTree.EndSequence();
            yield return null;
        }

        private IEnumerator VisualEnableHeroSkills()
        {
            var heroSkills = _heroLogic.Hero.HeroSkills;
            heroSkills.Skills.SetActive(true);
            
            
            _visualTree.EndSequence();
            yield return null;
        }

        







    }
}
