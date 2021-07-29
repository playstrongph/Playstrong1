using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

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
            //var speedConstant = _turnController.SpeedConstant;
            //var timerFull = _turnController.TimerFull;
            //var activeHeroes = _turnController.ActiveHeroes;
            
            foreach (var heroTimerObject in heroTimers)
            {
               
                /*var heroTimer = heroTimerObject as IHeroTimer;
                var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
                var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
                heroTimerObject.name = heroTimer.HeroLogic.Hero.ToString();

                heroTimer.TimerValue += heroSpeed * Time.deltaTime * speedConstant;
                heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / timerFull);
                heroTimer.HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(heroTimer.TimerValuePercentage);
                heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
                if (heroTimer.TimerValue >= timerFull)
                {
                    _turnController.FreezeTimers = true;
                    activeHeroes.Add(heroTimerObject);
                }*/
                
                UpdateHeroTimer(_turnController, heroTimerObject);

            }

        }
        
        //TEST - TODO: Transfer this to LivingStatus
        private void UpdateHeroTimer(ITurnController turnController, Object heroTimerObject)
        {
            //var heroTimers = _turnController.HeroTimers;
            var speedConstant = turnController.SpeedConstant;
            var timerFull = turnController.TimerFull;
            var activeHeroes = turnController.ActiveHeroes;
            
            
            var heroTimer = heroTimerObject as IHeroTimer;
            var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
            var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
            heroTimerObject.name = heroTimer.HeroLogic.Hero.ToString();

            heroTimer.TimerValue += heroSpeed * Time.deltaTime * speedConstant;
            heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / timerFull);
            heroTimer.HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(heroTimer.TimerValuePercentage);
            heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
            if (heroTimer.TimerValue >= timerFull)
            {
                _turnController.FreezeTimers = true;
                activeHeroes.Add(heroTimerObject);
            }
        }




    }
}
