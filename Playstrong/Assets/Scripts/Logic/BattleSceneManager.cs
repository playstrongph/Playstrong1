using System;
using System.Collections;
using GameSettings;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BattleSceneManager : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(IBattleSceneSettings))]
        private Object _battleSceneSettings;

        public IBattleSceneSettings BattleSceneSettings => _battleSceneSettings as IBattleSceneSettings;

        public ICoroutineTree LogicTree { get; set; }
        public ICoroutineTree VisualTree { get; set; }

        [SerializeField] [RequireInterface(typeof(IPlayerReferences))]
        private Object _mainPlayer;

        public IPlayerReferences MainPlayer => _mainPlayer as IPlayerReferences;
        
        [SerializeField] [RequireInterface(typeof(IPlayerReferences))]
        private Object _enemyPlayer;

        public IPlayerReferences EnemyPlayer => _enemyPlayer as IPlayerReferences;

        private void Awake()
        {
            LogicTree = BattleSceneSettings.BranchLogic.LogicTree;
            VisualTree = BattleSceneSettings.BranchLogic.VisualTree;
        }

        private void Start()
        {
            LogicTree.Start();
            VisualTree.Start();
            
            LogicTree.AddRoot(InitBattle());
        }

        private IEnumerator InitBattle()
        {
            LogicTree.AddCurrent(InitPlayers());
            LogicTree.AddCurrent(InitHeroes());
            
            yield return null;
            LogicTree.EndSequence();
        }

        private IEnumerator InitPlayers()
        {
            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroes()
        {
            var heroPrefab = BattleSceneSettings.HeroObjectPrefab;

            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var mainTeamTransform = BattleSceneSettings.AllyHeroesBoardLocation;
            LogicTree.AddCurrent(MainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform));

            //var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            //var enemyTeamTransform = BattleSceneSettings.EnemyHeroesBoardLocation;
            //LogicTree.AddCurrent(EnemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform));

            yield return null;
            LogicTree.EndSequence();
        }
        
        

        
    }
}
