using System;
using System.Collections;
using GameSettings;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BattleSceneManager : MonoBehaviour, IBattleSceneManager
    {
        [SerializeField] [RequireInterface(typeof(IBattleSceneSettings))]
        private Object _battleSceneSettings;

        public IBattleSceneSettings BattleSceneSettings => _battleSceneSettings as IBattleSceneSettings;

        public ICoroutineTree LogicTree { get; set; }
        public ICoroutineTree VisualTree { get; set; }
        
        private IPlayer _mainPlayer;
        private IPlayer _enemyPlayer;


        [SerializeField]
        [RequireInterface(typeof(ITurnController))]
        private Object _turnController;
        public ITurnController TurnController => _turnController as ITurnController;

        [SerializeField] [RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object _globalTrees;
        public ICoroutineTreesAsset GlobalTrees => _globalTrees as ICoroutineTreesAsset;
       
        private void Start()
       { 
           InitCoroutineTrees();
           
           LogicTree.AddCurrent(InitBattle());
        }

       private void InitCoroutineTrees()
       {
           LogicTree = GlobalTrees.MainLogicTree;
           VisualTree = GlobalTrees.MainVisualTree;
       }

       private IEnumerator InitBattle()
        {
            LogicTree.AddCurrent(InitPlayers());
            
            LogicTree.AddCurrent(InitHeroes());
            
            LogicTree.AddCurrent(InitHeroPortraits());
            LogicTree.AddCurrent(InitPanelPortraits());

            LogicTree.AddCurrent(InitSkills());
            LogicTree.AddCurrent(InitPanelSkills());
                
            LogicTree.AddCurrent(InitTurnController());    
            
            LogicTree.AddCurrent(StartBattle());

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
            LogicTree.AddCurrent(_mainPlayer.InitializePlayerHeroes.InitializeHeroes(mainTeamHeroAsset, heroPrefab, mainTeamTransform, heroPreviewLocations));


            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            var enemyTeamTransform = _enemyPlayer.LivingHeroes.Transform;
            LogicTree.AddCurrent(_enemyPlayer.InitializePlayerHeroes.InitializeHeroes(enemyTeamHeroAsset, heroPrefab, enemyTeamTransform, heroPreviewLocations));

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitHeroPortraits()
        {
           
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            
            var heroPortraitLocation = BattleSceneSettings.MainHeroPortraitLocation;

            LogicTree.AddCurrent(_mainPlayer.InitializeHeroPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation));
            LogicTree.AddCurrent(_mainPlayer.CreateHeroPortraitReferences.CreateReferences());

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            LogicTree.AddCurrent(_enemyPlayer.InitializeHeroPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, heroPortraitLocation));
            LogicTree.AddCurrent(_enemyPlayer.CreateHeroPortraitReferences.CreateReferences());
          

            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator InitPanelPortraits()
        {
            var heroPortraitPrefab = BattleSceneSettings.HeroPortraitPrefab;
            var panelPortraitLocation = BattleSceneSettings.PanelPortraitLocation;
            
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;

            LogicTree.AddCurrent(_mainPlayer.InitializePanelPortraits.InitializePortraits(mainTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation));
            LogicTree.AddCurrent(_mainPlayer.CreatePanelPortraitReferences.CreateReferences());

            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;
            
            LogicTree.AddCurrent(_enemyPlayer.InitializePanelPortraits.InitializePortraits(enemyTeamHeroAsset, heroPortraitPrefab, panelPortraitLocation));
            LogicTree.AddCurrent(_enemyPlayer.CreatePanelPortraitReferences.CreateReferences());

            yield return null;
            LogicTree.EndSequence();
        }
        
        

        private IEnumerator InitSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            var mainBoardLocation = _mainPlayer.HeroesSkills.Transform;
            var enemyBoardLocation = _enemyPlayer.HeroesSkills.Transform;

            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.SkillPreviewLocation;

            LogicTree.AddCurrent(_mainPlayer.InitializeHeroSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation,  skillPreviewLocation));
            LogicTree.AddCurrent(_mainPlayer.CreateHeroSkillReferences.CreateReferences());
            
            LogicTree.AddCurrent(_enemyPlayer.InitializeHeroSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation));
            LogicTree.AddCurrent(_enemyPlayer.CreateHeroSkillReferences.CreateReferences());

            yield return null;
            LogicTree.EndSequence();
            
        }
        
        private IEnumerator InitPanelSkills()
        {
            var mainTeamHeroAsset = BattleSceneSettings.PlayerTeamHeroesAsset;
            var enemyTeamHeroAsset = BattleSceneSettings.EnemyTeamHeroesAsset;

            var mainBoardLocation = _mainPlayer.PanelSkills.Transform;
            var enemyBoardLocation = _enemyPlayer.PanelSkills.Transform;
            
            
            var skillPanelPrefab = BattleSceneSettings.SkillPanelPrefab;
            var skillObjectPrefab = BattleSceneSettings.SkillObjectPrefab;
            var skillPreviewLocation = BattleSceneSettings.PanelSkillPreviewLocation;

            LogicTree.AddCurrent(_mainPlayer.InitializePanelSkills.InitializeSkills(mainTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, mainBoardLocation, skillPreviewLocation));
            LogicTree.AddCurrent(_mainPlayer.CreatePanelSkillReferences.CreateReferences());
            
            LogicTree.AddCurrent(_enemyPlayer.InitializePanelSkills.InitializeSkills(enemyTeamHeroAsset, skillPanelPrefab, skillObjectPrefab, enemyBoardLocation, skillPreviewLocation));
            LogicTree.AddCurrent(_enemyPlayer.CreatePanelSkillReferences.CreateReferences());
            
            LogicTree.AddCurrent(_mainPlayer.PanelSkills.DisablePanelSkillTargetVisual());
            LogicTree.AddCurrent(_enemyPlayer.PanelSkills.DisablePanelSkillTargetVisual());
            
            

            yield return null;
            LogicTree.EndSequence();
            
        }

        private IEnumerator InitTurnController()
        {
            foreach (var heroGameObject in _mainPlayer.LivingHeroes.HeroesList)
            {
                var heroTimer = heroGameObject.GetComponent<IHero>().HeroLogic.HeroTimer;
                
                TurnController.HeroTimers.Add(heroTimer as Object);
            }
            
            foreach (var heroGameObject in _enemyPlayer.LivingHeroes.HeroesList)
            {
                var heroTimer = heroGameObject.GetComponent<IHero>().HeroLogic.HeroTimer;
                
                TurnController.HeroTimers.Add(heroTimer as Object);
            }

            TurnController.LogicTree = LogicTree;
            TurnController.VisualTree = VisualTree;
            
            yield return null;
            LogicTree.EndSequence();
            
        }

        private IEnumerator StartBattle()
        {
            TurnController.StartTick();
            
            yield return null;
            LogicTree.EndSequence();
        }












    }
}
