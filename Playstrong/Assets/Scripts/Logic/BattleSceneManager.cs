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
            LogicTree.AddCurrent(InitSkills());
            
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
            var heroPreviewLocations = BattleSceneSettings.HeroPreviewLocations;
            
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var heroPortraitLocation = BattleSceneSettings.MainHeroPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var mainTeamTransform = BattleSceneSettings.AllyHeroesBoardLocation;
            
            LogicTree.AddCurrent(MainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations, LogicTree));
            LogicTree.AddCurrent(MainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            
            //TODO: Initialize PanelPortraits
            
            LogicTree.AddCurrent(MainPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));
            
            //TODO: CreatePanelPortrait References
           
            
            
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            var enemyTeamTransform = BattleSceneSettings.EnemyHeroesBoardLocation;
            
            LogicTree.AddCurrent(EnemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));
          
            
            
            yield return null;
            LogicTree.EndSequence();
        }

        private IEnumerator InitSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            var mainBoardLocation = BattleSceneSettings.AllySkillsBoardLocation;
            var enemyBoardLocation = BattleSceneSettings.EnemySkillsBoardLocation;
            
            
            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            
         
            
            LogicTree.AddCurrent(MainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, LogicTree));
            LogicTree.AddCurrent(MainPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(EnemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));
            
           
            
            
            yield return null;
            LogicTree.EndSequence();
            
        }






    }
}
