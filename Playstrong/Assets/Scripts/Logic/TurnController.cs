using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using ScriptableObjects;
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
        private IHeroLogic _activeHeroLogic;
        private int _activeHeroIndex;

        private ISortHeroesByEnergy _sortHeroesByEnergy;
        private IUpdateHeroTimers _updateHeroTimers;
        
       

        private void Awake()
        {
            _setHeroStatus = GetComponent<ISetHeroStatus>();
            _sortHeroesByEnergy = GetComponent<ISortHeroesByEnergy>();
            _updateHeroTimers = GetComponent<IUpdateHeroTimers>();
        }

        private void Start()
        {
            _logicTree = GlobalTrees.MainLogicTree;
            _visualTree = GlobalTrees.MainVisualTree;
        }

        public void StartHeroTurns()
        {
            _visualTree.AddCurrent(RunHeroTimers());
        }

        private IEnumerator RunHeroTimers()
        {
            _freezeTimers = false;

            while (!_freezeTimers)
            {
                yield return null;
                _updateHeroTimers.UpdateTimers();
            }
            
            _logicTree.AddCurrent(AllowHeroActions());
            
            yield return null;
            _visualTree.EndSequence();
        }
        
        private IEnumerator AllowHeroActions()
        {
            _logicTree.AddCurrent(_sortHeroesByEnergy.SortByEnergy());
            
            _logicTree.AddCurrent(SetHeroActive());
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetHeroActive()
        {
            _activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[_activeHeroIndex] as IHeroTimer;
            
            _activeHeroLogic = activeHeroTimer.HeroLogic;
            
            //HeroStatus to HeroActive
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroActive;
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);
            
            //UpdateSkillsStatus on HeroActive
            var updateSkills = _activeHeroLogic.Hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().UpdateHeroSkills.UpdateSkills();
            _logicTree.AddCurrent(updateSkills);

            yield return null;
            _logicTree.EndSequence(); 
        }

        private IEnumerator SetHeroInactive()
        {
            var i = ActiveHeroes.Count - 1;
            
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroInactive;
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);

            _activeHeroes.RemoveAt(i);

            yield return null;
            _logicTree.EndSequence(); 
        }

        private IEnumerator StartNextTurn()
        {
            _logicTree.AddCurrent(SetHeroInactive());
            _logicTree.AddCurrent(NextActiveHero());
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator NextActiveHero()
        {
            if(_activeHeroes.Count>0)
                _logicTree.AddCurrent(SetHeroActive());
            
            else
                _visualTree.AddCurrent(RunHeroTimers());


            yield return null;
            _logicTree.EndSequence();
        }


        public void EndTurn()
        {
            _logicTree.AddCurrent(StartNextTurn());
        }





    }
}
