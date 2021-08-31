using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class TurnControllerEvents : MonoBehaviour, ITurnControllerEvents
    {
        private ITurnController _turnController;
        private ITurnController TurnController => _turnController;

        private ICoroutineTree _logicTree;
        
        //TEST
        public delegate void TurnControlEvent();

        public event TurnControlEvent EStartCombatTurn;
        public event TurnControlEvent EEndCombatTurn;
        
        public void StartCombatTurn()
        {
            EStartCombatTurn?.Invoke();
        }
        
        private void UnsubscribeStartCombatTurnClients()
        {
            var clients = EStartCombatTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EStartCombatTurn -= client as TurnControlEvent;
                }
        }
        
        public void EndCombatTurn()
        {
            EEndCombatTurn?.Invoke();
        }
        
        private void UnsubscribeEndCombatTurnClients()
        {
            var clients = EEndCombatTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EEndCombatTurn -= client as TurnControlEvent;
                }
        }

        private void OnDestroy()
        {
            UnsubscribeStartCombatTurnClients();
            UnsubscribeEndCombatTurnClients();
        }


        //TEST END

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
            var heroObjects = _turnController.BattleSceneManager.EnemyPlayer.LivingHeroes.HeroesList;
            foreach (var heroObject in heroObjects)
            {
                var hero = heroObject.GetComponent<IHero>();
                hero.HeroLogic.HeroEvents.StartOfGame(hero, hero);
            }
        }







    }
}
