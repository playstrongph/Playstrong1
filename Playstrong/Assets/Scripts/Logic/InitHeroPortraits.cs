using System.Collections;
using System.Collections.Generic;
using GameSettings;
using UnityEngine;

namespace Logic
{
    public class InitHeroPortraits : MonoBehaviour, IInitHeroPortraits
    {
        
        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
        
        public IEnumerator InitializePortraits()
        {
           
            var heroPortraitPrefab = _battleSceneManager.BattleSceneSettings.HeroPortraitPrefab;
            var mainTeamHeroAsset = _battleSceneManager.BattleSceneSettings.PlayerTeamHeroesAsset;
            var heroPortraitLocation = _battleSceneManager.BattleSceneSettings.MainHeroPortraitLocation;
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;
            

            logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation));
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.CreateHeroPortraitReferences.CreateReferences());

            var enemyTeamHeroAsset = _battleSceneManager.BattleSceneSettings.EnemyTeamHeroesAsset;

            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation));
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.CreateHeroPortraitReferences.CreateReferences());
          

            yield return null;
            logicTree.EndSequence();
        }
        
    }
}
