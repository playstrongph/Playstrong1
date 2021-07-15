using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class StartOfGameEvent : MonoBehaviour, IStartOfGameEvent
    {
        private ITurnController _turnController;
        private ITurnController TurnController => _turnController;

        private ICoroutineTree _logicTree;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        public IEnumerator GameStartEvent()
        {
            _logicTree = _turnController.BattleSceneManager.LogicTree;
            
            AlliesStartOfGame();
            EnemiesStartOfGame();

            _logicTree.EndSequence();
            yield return null;
        }

        private void AlliesStartOfGame()
        {
            //Hero Game Objects
            var heroObjects = _turnController.BattleSceneManager.MainPlayer.LivingHeroes.HeroesList;
            foreach (var heroObject in heroObjects)
            {
                var hero = heroObject.GetComponent<IHero>();
                hero.HeroLogic.HeroEvents.StartOfGame(hero, hero);
            }
        }
        
        private void EnemiesStartOfGame()
        {
            //Hero Game Objects
            var heroObjects = _turnController.BattleSceneManager.MainPlayer.LivingHeroes.HeroesList;
            foreach (var heroObject in heroObjects)
            {
                var hero = heroObject.GetComponent<IHero>();
                hero.HeroLogic.HeroEvents.StartOfGame(hero, hero);
            }
        }







    }
}
