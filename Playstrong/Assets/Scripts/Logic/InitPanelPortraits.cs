using System.Collections;
using System.Collections.Generic;
using GameSettings;
using UnityEngine;

namespace Logic
{
    public class InitPanelPortraits : MonoBehaviour, IInitPanelPortraits
    {
        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
        
        public IEnumerator InitializePortraits()
        {
            var heroPortraitPrefab = _battleSceneManager.BattleSceneSettings.HeroPortraitPrefab;
            var panelPortraitLocation = _battleSceneManager.BattleSceneSettings.PanelPortraitLocation;
            var mainTeamHeroAsset = _battleSceneManager.BattleSceneSettings.PlayerTeamHeroesAsset;
            var logicTree = _battleSceneManager.GlobalTrees.MainLogicTree;

            logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializePanelPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation));
            logicTree.AddCurrent(_battleSceneManager.MainPlayer.CreatePanelPortraitReferences.CreateReferences());

            var enemyTeamHeroAsset = _battleSceneManager.BattleSceneSettings.EnemyTeamHeroesAsset;
            
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializePanelPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation));
            logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.CreatePanelPortraitReferences.CreateReferences());

            yield return null;
            logicTree.EndSequence();
        }
        
        
    }
}
