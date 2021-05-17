using System;
using UnityEngine;

namespace Logic
{
    public class UpdateHeroTimers : MonoBehaviour, IUpdateHeroTimers
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        

        public void UpdateTimers()
        {
            var heroTimers = _turnController.HeroTimers;
            var speedConstant = _turnController.SpeedConstant;
            var timerFull = _turnController.TimerFull;
            var activeHeroes = _turnController.ActiveHeroes;
            
            foreach (var heroTimerObject in heroTimers)
            {
                var heroTimer = heroTimerObject as IHeroTimer;
                var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
                var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
                heroTimerObject.name = heroTimer.HeroLogic.Hero.ToString();

                heroTimer.TimerValue += heroSpeed * Time.deltaTime * speedConstant;
                heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / timerFull);
                
                heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
                if (heroTimer.TimerValue >= timerFull)
                {
                    _turnController.FreezeTimers = true;
                    activeHeroes.Add(heroTimerObject);
                }

            }

        }
        
    
    }
}
