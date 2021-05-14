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

        public IPlayer MainPlayer
        {
            get => _mainPlayer;
            set => _mainPlayer = value;
        }


        private IPlayer _enemyPlayer;

        public IPlayer EnemyPlayer
        {
            get => _enemyPlayer;
            set => _enemyPlayer = value;
        }


        [SerializeField]
        [RequireInterface(typeof(ITurnController))]
        private Object _turnController;
        public ITurnController TurnController => _turnController as ITurnController;

        [SerializeField] [RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object _globalTrees;
        public ICoroutineTreesAsset GlobalTrees => _globalTrees as ICoroutineTreesAsset;

        private IInitPlayers _initPlayers;
        private IInitHeroes _initHeroes;
        private IInitHeroPortraits _initHeroPortraits;
        private IInitPanelPortraits _initPanelPortraits;
        private IInitSkills _initSkills;
        private IInitPanelSkills _initPanelSkills;

        


        private void Awake()
        {
            _initPlayers = GetComponent<IInitPlayers>();
            _initHeroes = GetComponent<IInitHeroes>();
            _initHeroPortraits = GetComponent<IInitHeroPortraits>();
            _initPanelPortraits = GetComponent<IInitPanelPortraits>();
            _initSkills = GetComponent<IInitSkills>();
            _initPanelSkills = GetComponent<IInitPanelSkills>();
        }


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
            LogicTree.AddCurrent(_initPlayers.InitializePlayers());
            LogicTree.AddCurrent(_initHeroes.InitializeHeroes());
            LogicTree.AddCurrent(_initHeroPortraits.InitializePortraits());
            LogicTree.AddCurrent(_initPanelPortraits.InitializePortraits());
            LogicTree.AddCurrent(_initSkills.InitializeSkills());
            LogicTree.AddCurrent(_initPanelSkills.InitializePanelSkills());
            
            LogicTree.AddCurrent(InitTurnController()); 
            LogicTree.AddCurrent(StartBattle());

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
