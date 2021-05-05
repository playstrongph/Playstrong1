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

        
        private void Start()
        {
            LogicTree = BattleSceneSettings.BranchLogic.LogicTree;
            VisualTree = BattleSceneSettings.BranchLogic.VisualTree;
            
            LogicTree.Start();
            VisualTree.Start();
            
            LogicTree.AddRoot(InitBattle());
        }

        private IEnumerator InitBattle()
        {
            LogicTree.AddCurrent(InitPlayers());
            
            LogicTree.AddCurrent(InitHeroes());
            
            LogicTree.AddCurrent(InitHeroPortraits());
            LogicTree.AddCurrent(InitPanelPortraits());

            LogicTree.AddCurrent(InitSkills());
            LogicTree.AddCurrent(InitPanelSkills());

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

            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var mainTeamTransform = BattleSceneSettings.AllyHeroesBoardLocation;
            
            LogicTree.AddCurrent(MainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations, LogicTree));


            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            var enemyTeamTransform = BattleSceneSettings.EnemyHeroesBoardLocation;
            
            LogicTree.AddCurrent(EnemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations, LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroPortraits()
        {
           
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var heroPortraitLocation = BattleSceneSettings.MainHeroPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;

            LogicTree.AddCurrent(MainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(MainPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            LogicTree.AddCurrent(EnemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitPanelPortraits()
        {
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var panelPortraitLocation = BattleSceneSettings.PanelPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;

            LogicTree.AddCurrent(MainPlayer.InitializePanelPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(MainPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            LogicTree.AddCurrent(EnemyPlayer.InitializePanelPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

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
            var skillPreviewLocation = BattleSceneSettings.SkillPreviewLocation;
            
         
            
            LogicTree.AddCurrent(MainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation,  skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(MainPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(EnemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        private IEnumerator InitPanelSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            var mainBoardLocation = BattleSceneSettings.AllyPanelSkillsLocation;
            var enemyBoardLocation = BattleSceneSettings.EnemyPanelSkillsLocation;
            
            
            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.PanelSkillPreviewLocation;
            
         
            
            LogicTree.AddCurrent(MainPlayer.InitializePanelSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(MainPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(EnemyPlayer.InitializePanelSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(EnemyPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        
        
        






    }
}
