﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class TestTurnController : MonoBehaviour, ITurnController
    {
        
        [SerializeField] [RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object _globalTrees;
        public ICoroutineTreesAsset GlobalTrees => _globalTrees as ICoroutineTreesAsset;

        [SerializeField] 
        private int _timerFull = 500;
        public int TimerFull => _timerFull;

        [SerializeField] private int _speedConstant = 10;
        public int SpeedConstant => _speedConstant;

        [SerializeField] private bool _freezeTimers = false;

        public bool FreezeTimers
        {
            get => _freezeTimers;
            set => _freezeTimers = value;
        }

        [SerializeField] 
        private List<Object> _heroTimers = new List<Object>();
        public List<Object> HeroTimers => _heroTimers as List<Object>;
    
        [SerializeField] 
        private List<Object> _activeHeroes = new List<Object>();
        public List<Object> ActiveHeroes => _activeHeroes as List<Object>;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        private ISetHeroStatus _setHeroStatus;
        public ISetHeroStatus SetHeroStatus => _setHeroStatus;
        
        private IHeroLogic _activeHeroLogic;
        private int _activeHeroIndex;
        private float _endTurnDelaySeconds = 0.5f;

        private ISortHeroesByEnergy _sortHeroesByEnergy;
        public ISortHeroesByEnergy SortHeroesByEnergy => _sortHeroesByEnergy;
        
        private IUpdateHeroTimers _updateHeroTimers;
        private IStartOfGameEvent _startOfGameEvent;
        

        private IBattleSceneManager _battleSceneManager;
        public IBattleSceneManager BattleSceneManager => _battleSceneManager;

        private IInitializeSkillEffects _initializeSkillEffects;
        public IInitializeSkillEffects InitializeSkillEffects => _initializeSkillEffects;


        private void Awake()
        {
            _setHeroStatus = GetComponent<ISetHeroStatus>();
            _sortHeroesByEnergy = GetComponent<ISortHeroesByEnergy>();
            _updateHeroTimers = GetComponent<IUpdateHeroTimers>();
            _battleSceneManager = GetComponentInParent<IBattleSceneManager>();
            _initializeSkillEffects = GetComponent<IInitializeSkillEffects>();
            _startOfGameEvent = GetComponent<IStartOfGameEvent>();
        }

        private void Start()
        {
            _logicTree = GlobalTrees.MainLogicTree;
            _visualTree = GlobalTrees.MainVisualTree;

           
        }
        
        /// <summary>
        /// This is the start of Game
        /// </summary>
        public void StartGame()
        {
         
            _logicTree.AddCurrent(InitializeSkillEffects.InitAllSkills());
            
            _logicTree.AddCurrent(_startOfGameEvent.GameStartEvent());

            _logicTree.AddCurrent(StartHeroTimers());
        }

        private IEnumerator StartHeroTimers()
        {
            _visualTree.AddCurrent(RunHeroTimers());
            
            _logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator RunHeroTimers()
        {
            _freezeTimers = false;

            while (!_freezeTimers)
            {
                yield return null;
                
                //TODO: make this pass by LivingStatus
                _updateHeroTimers.UpdateTimers();
            }
            
            _logicTree.AddCurrent(ActiveHeroesFound());
            
            _visualTree.EndSequence();
            yield return null;
            
        }
        
        private IEnumerator ActiveHeroesFound()
        {
            _logicTree.AddCurrent(_sortHeroesByEnergy.SortByEnergy());
            
            _logicTree.AddCurrent(StartHeroTurn());
            
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator StartHeroTurn()
        {
            _logicTree.AddCurrent(SetHeroActive());
            
            _logicTree.EndSequence();
            yield return null;
        }

        
        
        private IEnumerator StartNextHeroTurn()
        {
            _logicTree.AddCurrent(SetHeroInactive());
            
            _logicTree.AddCurrent(_sortHeroesByEnergy.SortByEnergy());
            _logicTree.AddCurrent(NextActiveHero());
            
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator NextActiveHero()
        {
            if (_activeHeroes.Count > 0)
                _logicTree.AddCurrent(SetHeroActive());
            else
                _logicTree.AddCurrent(StartHeroTimers());

            _logicTree.EndSequence();
            yield return null;
           
        }
        
        private IEnumerator SetHeroActive()
        {
            _activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[_activeHeroIndex] as IHeroTimer;
            _activeHeroLogic = activeHeroTimer.HeroLogic;
            
            //Set HeroStatus to active
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroActive;

            //Pre Start turn for StatusEffects effects
            _logicTree.AddCurrent(PreHeroStartTurnEvent());
            
            //Update Status Effect Counters
            _logicTree.AddCurrent(UpdateStatusEffectCountersStartTurn());

            //Start of Turn Event
            _logicTree.AddCurrent(HeroStartTurnEvent());

            //Update Skill Cooldown
            var updateSkills = _activeHeroLogic.Hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().UpdateHeroSkills.UpdateSkills();
            _logicTree.AddCurrent(updateSkills);
            
            //HeroStatus Actions
            _logicTree.AddCurrent(HeroStatusAction());

            _logicTree.EndSequence(); 
            yield return null;
           
        }

        private IEnumerator SetHeroInactive()
        {
            var heroTimer = _activeHeroLogic.HeroTimer;
            var heroTimerObject = heroTimer as Object;

            //This needs to come first before change of herostatus
            _activeHeroLogic.HeroStatus.RemoveFromActiveHeroesList(this, heroTimerObject);
            
            //Set Hero Status to Inactive
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroInactive;

            _logicTree.AddCurrent(HeroEndTurnEvent());
            
            _logicTree.AddCurrent(HeroStatusAction());
            
            _logicTree.AddCurrent(UpdateStatusEffectCountersEndTurn());

            _logicTree.EndSequence(); 
            yield return null;
        }

       

        //In the future, implement this as an IEnumerator and not a void
        public void EndTurn()
        {
            _logicTree.AddCurrentWait(_endTurnDelaySeconds, _logicTree);
            _visualTree.AddCurrentWait(_endTurnDelaySeconds, _visualTree);
            
            _logicTree.AddCurrent(StartNextHeroTurn());
        }
        
        //SetHeroActive Sub-methods
        private IEnumerator HeroStatusAction()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HeroStartTurnEvent()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.HeroEvents.HeroStartTurn(_activeHeroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PreHeroStartTurnEvent()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.HeroEvents.PreHeroStartTurn(_activeHeroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UpdateStatusEffectCountersStartTurn()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.Hero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersStartTurn();
            
            logicTree.EndSequence();
            yield return null;
        }
        
        //SetHeroInactive Sub-Methods
        private IEnumerator HeroEndTurnEvent()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.HeroEvents.HeroEndTurn(_activeHeroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UpdateStatusEffectCountersEndTurn()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.Hero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersEndTurn();
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        





    }
}