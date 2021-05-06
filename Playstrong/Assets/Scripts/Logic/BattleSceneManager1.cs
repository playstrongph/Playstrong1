﻿using System;
using System.Collections;
using GameSettings;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BattleSceneManager1 : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(IBattleSceneSettings))]
        private Object _battleSceneSettings;

        public IBattleSceneSettings BattleSceneSettings => _battleSceneSettings as IBattleSceneSettings;

        public ICoroutineTree LogicTree { get; set; }
        public ICoroutineTree VisualTree { get; set; }
        
        private IPlayer _mainPlayer;
        private IPlayer _enemyPlayer;

        
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
            var playerPrefab = BattleSceneSettings.Player;
            var playersParent = BattleSceneSettings.BattleSceneManagerTransform;

            var mainPlayerGameObject = Instantiate(playerPrefab, playersParent);
            mainPlayerGameObject.name = "MainPlayer";

            var mainPlayer = mainPlayerGameObject.GetComponent<IPlayer>();
            mainPlayer.LivingHeroes.Transform.position = BattleSceneSettings.AllyHeroesBoardLocation.position;

            _mainPlayer = mainPlayer;
            
            var enemyPlayerGameObject = Instantiate(playerPrefab, playersParent);
            enemyPlayerGameObject.name = "EnemyPlayer";

            var enemyPlayer = enemyPlayerGameObject.GetComponent<IPlayer>();
            enemyPlayer.LivingHeroes.Transform.position = BattleSceneSettings.EnemyHeroesBoardLocation.position;

            _enemyPlayer = enemyPlayer;

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroes()
        {
            var heroPrefab = BattleSceneSettings.HeroObjectPrefab;
            var heroPreviewLocations = BattleSceneSettings.HeroPreviewLocations;

            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var mainTeamTransform = _mainPlayer.LivingHeroes.Transform;
            LogicTree.AddCurrent(_mainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations, LogicTree));


            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            var enemyTeamTransform = _enemyPlayer.LivingHeroes.Transform;
            LogicTree.AddCurrent(_enemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations, LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroPortraits()
        {
           
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            
            var heroPortraitLocation = BattleSceneSettings.MainHeroPortraitLocation;

            LogicTree.AddCurrent(_mainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(_mainPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            LogicTree.AddCurrent(_enemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(_enemyPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitPanelPortraits()
        {
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var panelPortraitLocation = BattleSceneSettings.PanelPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;

            LogicTree.AddCurrent(_mainPlayer.InitializePanelPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(_mainPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            LogicTree.AddCurrent(_enemyPlayer.InitializePanelPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(_enemyPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        

        private IEnumerator InitSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            //var mainSkillsLocation = _mainPlayer.HeroSkillsList.Transform;
            var mainSkillsLocation = BattleSceneSettings.AllySkillsBoardLocation;
            
            //var enemySkillsLocation = _enemyPlayer.HeroSkillsList.Transform;
            var enemySkillsLocation = BattleSceneSettings.EnemySkillsBoardLocation;

            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.SkillPreviewLocation;
            
            //test
            var mainPlayerHeroList = _mainPlayer.LivingHeroes.ThisList;
            var enemyPlayerHeroList = _enemyPlayer.LivingHeroes.ThisList;

            LogicTree.AddCurrent(_mainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, 
                mainSkillsLocation,  skillPreviewLocation, LogicTree, mainPlayerHeroList));
            //LogicTree.AddCurrent(_mainPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(_enemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, 
                enemySkillsLocation, skillPreviewLocation, LogicTree, enemyPlayerHeroList));
            //LogicTree.AddCurrent(_enemyPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        private IEnumerator InitPanelSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            var mainBoardLocation = _mainPlayer.PanelSkillsList.Transform;
            var enemyBoardLocation = _enemyPlayer.PanelSkillsList.Transform;
            
            
            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.PanelSkillPreviewLocation;

            LogicTree.AddCurrent(_mainPlayer.InitializePanelSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(_mainPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(_enemyPlayer.InitializePanelSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(_enemyPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        
        
        






    }
}
