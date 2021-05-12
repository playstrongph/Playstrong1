using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SetHeroActive : MonoBehaviour, ISetHeroActive
    {
        private IHeroTimer _heroTimer;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _heroTimer = GetComponent<IHeroTimer>();
        }

        public IEnumerator SetActive(ICoroutineTree logicTree, ICoroutineTree visualTree)
        {
            //isActive = true;
            _logicTree = logicTree;
            _visualTree = visualTree;
            
            ResetHeroTimer();
            
            //TODO: Visual: Clear all existing Hero Glows
            
            //TODO: Visual: Display HeroGlow, HeroSkills, HeroPortrait
            visualTree.AddCurrent(VisualHeroActiveGlow());
            
            
            //TODO: Visual: Display Valid Target Glows - Implement this on basicAttack/Skill OnMouseDown

            yield return null;
            logicTree.EndSequence();
        }

        private void ResetHeroTimer()
        {
            var heroEnergyVisual = _heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
            
            _heroTimer.TimerValue = 0;
            _heroTimer.TimerValuePercentage = 0;
            heroEnergyVisual.SetEnergyTextAndBarFill((int)_heroTimer.TimerValuePercentage);
        }

        private IEnumerator VisualHeroActiveGlow()
        {
            var heroVisual = _heroTimer.HeroLogic.Hero.HeroVisual;
            var heroFrame = heroVisual.SelectActiveHeroFrame.ActiveHeroFrame;
            
            heroFrame.ActionGlowFrame.SetActive(true);

            yield return null;
            _visualTree.EndSequence();

        }
        
        



    }
}
