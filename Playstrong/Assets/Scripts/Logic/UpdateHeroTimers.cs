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
        
        //TEST
        private List<GameObject> _allLivingHeroes = new List<GameObject>();
        

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        

        public void UpdateTimers2()
        {
            var heroTimers = _turnController.HeroTimers;
            
            foreach (var heroTimerObject in heroTimers)
            {
                UpdateHeroTimer(_turnController, heroTimerObject);
            }

        }
        
        //TODO: Transfer this to HeroTimer and access via livingStatus
        private void UpdateHeroTimer(ITurnController turnController, Object heroTimerObject)
        {
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
        
        //TEST START

        public void UpdateTimers()
        {
            GetAllLivingHeroes();
            UpdateLivingHeroesTimers();
        }

        private void UpdateLivingHeroesTimers()
        {
            foreach (var heroObject in _allLivingHeroes)
            {
                var hero = heroObject.GetComponent<IHero>();
                var heroTimer = hero.HeroLogic.HeroTimer;
                heroTimer.UpdateHeroTimer(_turnController);
                
                 if (heroTimer.TimerValue >= _turnController.TimerFull)
                 {
                     _turnController.FreezeTimers = true;
                     _turnController.ActiveHeroes.Add(heroTimer as Object);
                 }
            }
        }

        private void GetAllLivingHeroes()
        {
            var allyHeroes = _turnController.BattleSceneManager.MainPlayer.LivingHeroes.HeroesList;
            var enemyHeroes = _turnController.BattleSceneManager.EnemyPlayer.LivingHeroes.HeroesList;
            
            _allLivingHeroes.Clear();
            
            foreach (var allyHero in allyHeroes)
            {
                _allLivingHeroes.Add(allyHero);
            }
            
            foreach (var enemyHero in enemyHeroes)
            {
                _allLivingHeroes.Add(enemyHero);
            }
        }

        //TEST END



    }
}
