using System;
using System.Collections;
using System.Collections.Generic;
using GameSettings;
using UnityEngine;

namespace Logic
{
    public class InitHeroes : MonoBehaviour, IInitHeroes
    {

        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }

        public IEnumerator InitializeHeroes()
        {
            var heroPrefab = _battleSceneManager.BattleSceneSettings.HeroObjectPrefab;
            var heroPreviewLocations = _battleSceneManager.BattleSceneSettings.HeroPreviewLocations;
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;

            var mainTeamHeroAsset = _battleSceneManager.BattleSceneSettings.PlayerTeamHeroesAsset;
            var mainTeamTransform = _battleSceneManager.MainPlayer.LivingHeroes.Transform;
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations));


            var enemyTeamHeroAsset = _battleSceneManager.BattleSceneSettings.EnemyTeamHeroesAsset;
            var enemyTeamTransform = _battleSceneManager.EnemyPlayer.LivingHeroes.Transform;
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations));

            yield return null;
            logicTree.EndSequence();
        }
        
        
    }
}
