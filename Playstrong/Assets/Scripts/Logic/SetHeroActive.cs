using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SetHeroActive : MonoBehaviour, ISetHeroActive
    {
        private IHeroTimer _heroTimer;

        private void Awake()
        {
            _heroTimer = GetComponent<IHeroTimer>();
        }

        public IEnumerator SetActive(ICoroutineTree logicTree)
        {
            //isActive = true;
            
            ResetHeroTimer();
            
            //TODO: Visual: Clear all existing Hero Glows
            //TODO: Visual: Display HeroGlow, HeroSkills, HeroPortrait
            
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

    }
}
