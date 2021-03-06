using System;
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
        public ISortHeroesByEnergy SortHeroesByEnergy => _sortHeroesByEnergy;
        
        private IUpdateHeroTimers _updateHeroTimers;
        
        private ITurnControllerEvents _turnControllerEvents;
        public ITurnControllerEvents TurnControllerEvents => _turnControllerEvents;


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
            _turnControllerEvents = GetComponent<ITurnControllerEvents>();
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
            
            _logicTree.AddCurrent(TurnControllerEvents.GameStartEvent());

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
            
            _logicTree.AddCurrent(PreHeroStartTurn());
            
            _logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator PreHeroStartTurn()
        {
            //TODO: Initialize _activeHeroLogic
            //_logicTree.AddCurrent(InitializeActiveHeroLogic());
            InitializeActiveHeroLogic();
            
            //TEST - Hero Should be active HERE
            _logicTree.AddCurrent(SetHeroActive());
            
            //TEST
            //TODO: StartOfCombatEvent
            _logicTree.AddCurrent(StartCombatTurnEvent());
            
            //Reset Energy
            _logicTree.AddCurrent(ResetEnergyToZero());
            
            //Pre Start turn for StatusEffects effects
            _logicTree.AddCurrent(PreHeroStartTurnEvent());
            
            //Update Status Effect Counters
            _logicTree.AddCurrent(UpdateStatusEffectCountersStartTurn());
            
            //TODO: SetHeroInabilityStatus
            //if No InabilityEffects - StartHeroTurn, else - StartNextHeroTurn
            _logicTree.AddCurrent(SetHeroInabilityStatus());
            
            //TODO: HeroInabilityStatus
            //_logicTree.AddCurrent(_activeHeroLogic.HeroInabilityStatus.StatusAction(this));
            
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        //TEST
        private IEnumerator StartCombatTurnEvent()
        {
            TurnControllerEvents.StartCombatTurn();
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EndCombatTurnEvent()
        {
            TurnControllerEvents.EndCombatTurn();
            
            _logicTree.EndSequence();
            yield return null;
        }

        //TEST END
        

        public IEnumerator StartHeroTurn()
        {
            //Update Skill Cooldown - comes first in consideration of effects such as silence
            //_logicTree.AddCurrent(UpdateHeroSkillsCooldown(_activeHeroLogic));
            _logicTree.AddCurrent(UpdateHeroSkillsReadinessStatus(_activeHeroLogic));

            //Start of StartHeroTurn method
            _logicTree.AddCurrent(HeroStartTurnEvent());

            //Enable Action Phase UI
            _logicTree.AddCurrent(UpdateHeroActionPhase());
            
            _logicTree.EndSequence();
            yield return null;
        }

        public IEnumerator StartNextHeroTurn()
        {
            //TEST
            _logicTree.AddCurrent(UpdateHeroSkillsCooldown(_activeHeroLogic));
            
            //Post End turn for StatusEffects effects
            _logicTree.AddCurrent(PostHeroEndTurnEvent());
            
            //TEST            
            //TODO: EndCombatTurnEvent
            _logicTree.AddCurrent(EndCombatTurnEvent());
            
            _logicTree.AddCurrent(UpdateStatusEffectCountersEndTurn());

            //Need to sort again because of increase energy effects
            _logicTree.AddCurrent(_sortHeroesByEnergy.SortByEnergy());
            
            _logicTree.AddCurrent(StartNextActiveHero());
            
            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator StartNextActiveHero()
        {
            if (_activeHeroes.Count > 0)
                _logicTree.AddCurrent(PreHeroStartTurn());
                //TODO: Change this to PreHeroStartTurn
                //_logicTree.AddCurrent(StartHeroTurn());
            else
                _logicTree.AddCurrent(StartHeroTimers());

            _logicTree.EndSequence();
            yield return null;
           
        }
        
        private IEnumerator SetHeroActive()
        {
            //Debug.Log("Set HeroStatus Active");
            //Set HeroStatus to active
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroActive;

            _logicTree.EndSequence(); 
            yield return null;
           
        }

        public IEnumerator SetCurrentHeroInactive()
        {
            
            var heroTimer = _activeHeroLogic.HeroTimer;
            var heroTimerObject = heroTimer as Object;

            //This needs to come first before change of herostatus
            _activeHeroLogic.HeroStatus.RemoveFromActiveHeroesList(this, heroTimerObject);
            
            //Debug.Log("Set Current Hero Inactive: " +_activeHeroLogic.Hero.HeroName);
            //Set Hero Status to Inactive
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroInactive;
            
            //TEST Nov 12 2021
            //_logicTree.AddCurrent(UpdateHeroActionPhase());

            _logicTree.EndSequence(); 
            yield return null;
        }

        private IEnumerator EndCurrentHeroTurn()
        {
            //original    
            //_logicTree.AddCurrent(SetCurrentHeroInactive());
            
            _logicTree.AddCurrent(HeroEndTurnEvent());
            
            //TEST Nov 12 2021
            _logicTree.AddCurrent(SetCurrentHeroInactive());
            
            _logicTree.AddCurrent(UpdateHeroActionPhase());
            
            _logicTree.EndSequence();
            
            yield return null;
        }



        //In the future, implement this as an IEnumerator and not a void
        public void EndCombatTurn()
        {
            //_logicTree.AddCurrentWait(_endTurnDelaySeconds, _logicTree);
            
            _visualTree.AddCurrentWait(_endTurnDelaySeconds, _visualTree);
            
            //_logicTree.AddCurrent(EndCurrentHeroTurn());
            //_logicTree.AddCurrent(StartNextHeroTurn());
            
            //This seems to work better than addCurrent for now
            _logicTree.AddSibling(EndCurrentHeroTurn());
            
            _logicTree.AddSibling(StartNextHeroTurn());
        }

        private void InitializeActiveHeroLogic()
        {
            _activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[_activeHeroIndex] as IHeroTimer;
            _activeHeroLogic = activeHeroTimer.HeroLogic;

            //_logicTree.EndSequence();
            //yield return null;
        }

        private IEnumerator ResetEnergyToZero()
        {
            _visualTree.AddCurrent(ResetEnergyAnimation());
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator ResetEnergyAnimation()
        {
            _activeHeroLogic.HeroTimer.ResetHeroTimer();
            
            _visualTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator SetHeroInabilityStatus()
        {
            var heroDisabled = _activeHeroLogic.HeroInabilityStatusAssets.WithHeroInabilityStatus;
            var heroEnabled = _activeHeroLogic.HeroInabilityStatusAssets.NoHeroInabilityStatus;
            var heroInabilityChance = _activeHeroLogic.OtherAttributes.HeroInabilityChance;
            var heroInabilityResistance = _activeHeroLogic.OtherAttributes.HeroInabilityResistance;
            var netChance = heroInabilityChance - heroInabilityResistance;
            var randomChance = UnityEngine.Random.Range(0f, 100f);

            _activeHeroLogic.HeroInabilityStatus = randomChance <= netChance ? heroDisabled : heroEnabled;

            _logicTree.AddCurrent(_activeHeroLogic.HeroInabilityStatus.StatusAction(this));

            _logicTree.EndSequence();
            yield return null;
        }

        //SetHeroActive Sub-methods
        private IEnumerator UpdateHeroActionPhase()
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
        
        private IEnumerator PostHeroEndTurnEvent()
        {
            var logicTree = _activeHeroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            
            _activeHeroLogic.HeroEvents.PostHeroEndTurn(_activeHeroLogic.Hero);
            
            //TODO: this.TurnControllerEvents.EndCombatTurn()
            
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

        private IEnumerator UpdateHeroSkillsCooldown(IHeroLogic heroLogic)
        {
            var updateSkillCooldown = heroLogic.Hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().UpdateHeroSkills.UpdateSkills();
            
            _logicTree.AddCurrent(updateSkillCooldown);
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator UpdateHeroSkillsReadinessStatus(IHeroLogic heroLogic)
        {
            var updateSkillReadiness = heroLogic.Hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().UpdateHeroSkills.UpdateSkillReadinessStatus();
            
            _logicTree.AddCurrent(updateSkillReadiness);
            
            _logicTree.EndSequence();
            yield return null;
        }


    }
}
