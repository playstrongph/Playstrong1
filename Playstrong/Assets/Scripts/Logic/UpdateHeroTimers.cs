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
        private readonly List<IHero> _allLivingHeroes = new List<IHero>();
        

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        public void UpdateTimers()
        {
            GetAllLivingHeroes();
            UpdateLivingHeroesTimers();
        }

        private void UpdateLivingHeroesTimers()
        {
            foreach (var hero in _allLivingHeroes)
            {
                var heroTimer = hero.HeroLogic.HeroTimer;
                heroTimer.UpdateHeroTimer(_turnController);
            }
        }

        private void GetAllLivingHeroes()
        {
            var allyHeroes = _turnController.BattleSceneManager.MainPlayer.LivingHeroes;
            var enemyHeroes = _turnController.BattleSceneManager.EnemyPlayer.LivingHeroes;
            
           
            
            _allLivingHeroes.Clear();
            
            foreach (var allyHero in allyHeroes.LivingHeroesList)
            {
                _allLivingHeroes.Add(allyHero);
            }
            
            foreach (var enemyHero in enemyHeroes.LivingHeroesList)
            {
                _allLivingHeroes.Add(enemyHero);
            }
        }

    }
}
