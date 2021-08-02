using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class TurnController : MonoBehaviour, ITurnController
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
        public void StartHeroTurns()
        {
         
            _logicTree.AddCurrent(InitializeSkillEffects.InitAllSkills());
            
            _logicTree.AddCurrent(_startOfGameEvent.GameStartEvent());

            _logicTree.AddCurrent(RunHeroTimers());
        }

        private IEnumerator RunHeroTimers()
        {
            _visualTree.AddCurrent(RunHeroTimersVisual());
            
            _logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator RunHeroTimersVisual()
        {
            _freezeTimers = false;

            while (!_freezeTimers)
            {
                yield return null;
                
                //TODO: make this pass by LivingStatus
                _updateHeroTimers.UpdateTimers();
            }
            
            _logicTree.AddCurrent(AllowHeroActions());
            
            _visualTree.EndSequence();
            yield return null;
            
        }
        
        private IEnumerator AllowHeroActions()
        {
            _logicTree.AddCurrent(_sortHeroesByEnergy.SortByEnergy());
            
            _logicTree.AddCurrent(SetHeroActive());
            
            _logicTree.EndSequence();
            yield return null;
           
        }

        private IEnumerator SetHeroActive()
        {
            _activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[_activeHeroIndex] as IHeroTimer;
            _activeHeroLogic = activeHeroTimer.HeroLogic;
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroActive;
            var updateSkills = _activeHeroLogic.Hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().UpdateHeroSkills.UpdateSkills();
            
            //HeroActive and HeroInactive Status Action
            //TODO: Convert to coroutine
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);
            
            //Start of Turn Event
            //TODO: Convert to coroutine
            _activeHeroLogic.HeroEvents.HeroStartTurn(_activeHeroLogic.Hero);
            
            //Update Skill Cooldown and Status Effect Counters
            
            _logicTree.AddCurrent(updateSkills);
            
            //TODO: Convert to Coroutine
            _activeHeroLogic.Hero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersStartTurn();
            
            
            //Status Effect Triggers
            //_activeHeroLogic.Hero.HeroStatusEffects.StartTurnStatusEffects.TriggerStatusEffect();

            _logicTree.EndSequence(); 
            yield return null;
           
        }

        private IEnumerator SetHeroInactive()
        {
            var i = ActiveHeroes.Count - 1;
            
            //Status Effect Triggers
            _activeHeroLogic.Hero.HeroStatusEffects.EndTurnStatusEffects.TriggerStatusEffect();
            _activeHeroLogic.Hero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersEndTurn();
            
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroInactive;
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);

            _activeHeroes.RemoveAt(i);
            
            _logicTree.EndSequence(); 
            yield return null;
           
        }

        private IEnumerator StartNextTurn()
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
                _logicTree.AddCurrent(RunHeroTimers());

            _logicTree.EndSequence();
            yield return null;
           
        }


        public void EndTurn()
        {
            _logicTree.AddCurrentWait(_endTurnDelaySeconds, _logicTree);
            _visualTree.AddCurrentWait(_endTurnDelaySeconds, _visualTree);
            
            _logicTree.AddCurrent(StartNextTurn());
        }





    }
}
