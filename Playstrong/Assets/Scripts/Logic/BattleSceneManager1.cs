using System;
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

        [SerializeField] [RequireInterface(typeof(IPlayer))]
        private Object _mainPlayer;

        public IPlayer MainPlayer => _mainPlayer as IPlayer;

       
        
        [SerializeField] [RequireInterface(typeof(IPlayer))]
        private Object _enemyPlayer;

        public IPlayer EnemyPlayer => _enemyPlayer as IPlayer;
        
       
        private IPlayer newMainPlayer;
        private IPlayer newEnemyPlayer;

        
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
            mainPlayerGameObject.name = "NewMainPlayer";

            var mainPlayer = mainPlayerGameObject.GetComponent<IPlayer>();
            mainPlayer.LivingHeroes.GetTransform().position = BattleSceneSettings.AllyHeroesBoardLocation.position;

            newMainPlayer = mainPlayer;
            
            var enemyPlayerGameObject = Instantiate(playerPrefab, playersParent);
            enemyPlayerGameObject.name = "NewEnemyPlayer";

            var enemyPlayer = enemyPlayerGameObject.GetComponent<IPlayer>();
            enemyPlayer.LivingHeroes.GetTransform().position = BattleSceneSettings.EnemyHeroesBoardLocation.position;

            newEnemyPlayer = enemyPlayer;

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroes()
        {
            var heroPrefab = BattleSceneSettings.HeroObjectPrefab;
            var heroPreviewLocations = BattleSceneSettings.HeroPreviewLocations;

            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            
            //var mainTeamTransform = BattleSceneSettings.AllyHeroesBoardLocation;
            var mainTeamTransform = newMainPlayer.LivingHeroes.GetTransform();
            
            LogicTree.AddCurrent(newMainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations, LogicTree));


            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            //var enemyTeamTransform = BattleSceneSettings.EnemyHeroesBoardLocation;
            var enemyTeamTransform = newEnemyPlayer.LivingHeroes.GetTransform();
            
            LogicTree.AddCurrent(newEnemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations, LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroPortraits()
        {
           
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            
            var heroPortraitLocation = BattleSceneSettings.MainHeroPortraitLocation;

            LogicTree.AddCurrent(newMainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(newMainPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            LogicTree.AddCurrent(newEnemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation, LogicTree));
            LogicTree.AddCurrent(newEnemyPlayer.CreateHeroPortraitReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitPanelPortraits()
        {
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var panelPortraitLocation = BattleSceneSettings.PanelPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;

            LogicTree.AddCurrent(newMainPlayer.InitializePanelPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(newMainPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            LogicTree.AddCurrent(newEnemyPlayer.InitializePanelPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation, LogicTree));
            LogicTree.AddCurrent(newEnemyPlayer.CreatePanelPortraitReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
        }
        
        

        private IEnumerator InitSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            //var mainBoardLocation = BattleSceneSettings.AllySkillsBoardLocation;
            //var enemyBoardLocation = BattleSceneSettings.EnemySkillsBoardLocation;

            var mainBoardLocation = newMainPlayer.HeroSkillsList.GetTransform();
            var enemyBoardLocation = newEnemyPlayer.HeroSkillsList.GetTransform();

            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.SkillPreviewLocation;
            
         
            
            LogicTree.AddCurrent(newMainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation,  skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(newMainPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(newEnemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(newEnemyPlayer.CreateHeroSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        private IEnumerator InitPanelSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            //var mainBoardLocation = BattleSceneSettings.AllyPanelSkillsLocation;
            //var enemyBoardLocation = BattleSceneSettings.EnemyPanelSkillsLocation;
            
            var mainBoardLocation = newMainPlayer.PanelSkillsList.GetTransform();
            var enemyBoardLocation = newEnemyPlayer.PanelSkillsList.GetTransform();
            
            
            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.PanelSkillPreviewLocation;
            
         
            
            LogicTree.AddCurrent(newMainPlayer.InitializePanelSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(newMainPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));
            
            LogicTree.AddCurrent(newEnemyPlayer.InitializePanelSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation, LogicTree));
            LogicTree.AddCurrent(newEnemyPlayer.CreatePanelSkillReferences.CreateReferences(LogicTree));

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        
        
        






    }
}
