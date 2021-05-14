using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SetHeroActive : MonoBehaviour, ISetHeroActive
    {
        private IHeroTimer _heroTimer;
        private IHeroLogic _heroLogic;
        private IHero _hero;

        private IHeroVisual _heroVisual;

        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
            
            _heroTimer = _heroLogic.HeroTimer;
            _hero = _heroLogic.Hero;
            _heroVisual = _hero.HeroVisual;

        }

        private void Start()
        {
            _logicTree = _hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _hero.CoroutineTreesAsset.MainVisualTree;
        }


        public IEnumerator SetActive()
        {
            //TODO: isActive = true;
            
            ResetHeroTimer();
            
            //TODO: Visual: Clear all existing Hero Glows?
            
            //TODO: Visual: Display HeroGlow, HeroSkills, HeroPortrait
            _visualTree.AddCurrent(VisualActionHeroGlow());
            _visualTree.AddCurrent(VisualHeroPortrait());
            _visualTree.AddCurrent(VisualHeroSkills());

            //TODO: Visual: Display Valid Target Glows - Implement this on basicAttack/Skill OnMouseDown?

            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator VisualActionHeroGlow()
        {
            var actionGlowFrame = _heroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            actionGlowFrame.SetActive(true);

            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualHeroPortrait()
        {
            var heroPortrait = _hero.HeroPortrait;
            heroPortrait.Portrait.SetActive(true);
           
            
            yield return null;
            _visualTree.EndSequence();
        }

        private IEnumerator VisualHeroSkills()
        {
            var heroSkills = _hero.Skills;
            heroSkills.Skills.SetActive(true);
            
            yield return null;
            _visualTree.EndSequence();
        }


        private void ResetHeroTimer()
        {
            var heroEnergyVisual = _heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
            
            _heroTimer.TimerValue = 0;
            _heroTimer.TimerValuePercentage = 0;
            heroEnergyVisual.SetEnergyTextAndBarFill((int)_heroTimer.TimerValuePercentage);
        }

       

    }
}
