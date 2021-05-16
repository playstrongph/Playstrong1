using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class UpdateHeroTimers : MonoBehaviour, IUpdateHeroTimers
    {

        private ITurnController _turnController;
        private List<Object> _heroTimers;
        private int _speedConstant;
        private int _timerFull;
        private List<Object> _activeHeroes;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        private void Start()
        {
            _heroTimers = _turnController.HeroTimers;
            _speedConstant = _turnController.SpeedConstant;
            _timerFull = _turnController.TimerFull;
            _activeHeroes = _turnController.ActiveHeroes;

        }


        public void UpdateTimers()
        {
            foreach (var heroTimerObject in _heroTimers)
            {
                
                var heroTimer = heroTimerObject as IHeroTimer;
                var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
                var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
                heroTimerObject.name = heroTimer.HeroLogic.Hero.ToString();
                

                heroTimer.TimerValue += heroSpeed * Time.deltaTime * _speedConstant;
                heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / _timerFull);
                
                heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
                if (heroTimer.TimerValue >= _timerFull)
                {
                    _turnController.FreezeTick = true;
                    _activeHeroes.Add(heroTimerObject);
                }

            }

        }
        
        
        
    }
}
