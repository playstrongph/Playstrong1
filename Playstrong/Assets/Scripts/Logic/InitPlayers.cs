using System;
using System.Collections;
using System.Collections.Generic;
using GameSettings;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class InitPlayers : MonoBehaviour, IInitPlayers
    {
        private IBattleSceneManager _battleSceneManager;
        

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
            
        }

        public IEnumerator InitializePlayers()
        {
            var playerPrefab = _battleSceneManager.BattleSceneSettings.Player;
            var playersParent = _battleSceneManager.BattleSceneSettings.BattleSceneManagerTransform;
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;

            var mainPlayerGameObject = Instantiate(playerPrefab, playersParent);
            mainPlayerGameObject.name = "MainPlayer";

            var mainPlayer = mainPlayerGameObject.GetComponent<IPlayer>();
            mainPlayer.LivingHeroes.Transform.position = _battleSceneManager.BattleSceneSettings.AllyHeroesBoardLocation.position;

            _battleSceneManager.MainPlayer = mainPlayer;

            var enemyPlayerGameObject = Instantiate(playerPrefab, playersParent);
            enemyPlayerGameObject.name = "EnemyPlayer";

            var enemyPlayer = enemyPlayerGameObject.GetComponent<IPlayer>();
            enemyPlayer.LivingHeroes.Transform.position = _battleSceneManager.BattleSceneSettings.EnemyHeroesBoardLocation.position;

            _battleSceneManager.EnemyPlayer = enemyPlayer;

            yield return null;
            logicTree.EndSequence();
        }
    
    
    }
}
