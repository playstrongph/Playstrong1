using System;
using System.Collections;
using GameSettings;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.Others;
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
        private IInitTurnController _initTurnController;
        private IStartBattle _startBattle;
        private IInitializeHeroPassiveSkills _initializeHeroPassiveSkills;

        private void Awake()
        {
            _initPlayers = GetComponent<IInitPlayers>();
            _initHeroes = GetComponent<IInitHeroes>();
            _initHeroPortraits = GetComponent<IInitHeroPortraits>();
            _initPanelPortraits = GetComponent<IInitPanelPortraits>();
            _initSkills = GetComponent<IInitSkills>();
            _initPanelSkills = GetComponent<IInitPanelSkills>();
            _initTurnController = GetComponent<IInitTurnController>();
            _startBattle = GetComponent<IStartBattle>();
            _initializeHeroPassiveSkills = GetComponent<IInitializeHeroPassiveSkills>();
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
            LogicTree.AddCurrent(_initTurnController.InitializeTurnController());
            LogicTree.AddCurrent(_startBattle.BattleStart());
            
            LogicTree.AddCurrent(_initializeHeroPassiveSkills.InitPassiveSkills());

            yield return null;
            LogicTree.EndSequence();
        }
       
      
       
       
       

       

        












    }
}
