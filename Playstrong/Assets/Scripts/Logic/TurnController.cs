using System;
using System.Collections;
using System.Collections.Generic;
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
        private int _timerFull = 1000;
        public int TimerFull => _timerFull;

        [SerializeField] private int _speedConstant = 5;
        public int SpeedConstant => _speedConstant;

        [SerializeField] private bool _freezeTick = false;
        public bool FreezeTick => _freezeTick;

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

        private void Awake()
        {
            _setHeroStatus = GetComponent<ISetHeroStatus>();
        }

        private void Start()
        {
            _logicTree = GlobalTrees.MainLogicTree;
            _visualTree = GlobalTrees.MainVisualTree;
        }


        public void StartHeroTurns()
        {
            _logicTree.AddCurrent(RunHeroTimers());
        }

        private IEnumerator RunHeroTimers()
        {
            _freezeTick = false;

            while (!_freezeTick)
            {
                yield return null;
                UpdateHeroTimers();
            }

            _logicTree.AddCurrent(AllowHeroActions());
            
            yield return null;
            _logicTree.EndSequence();
        }


        private void UpdateHeroTimers()
        {
           
            foreach (var heroTimerObject in _heroTimers)
            {
                
                var heroTimer = heroTimerObject as IHeroTimer;
                var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
                var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;
                heroTimerObject.name = heroTimer.HeroLogic.Hero.ToString();
                

                heroTimer.TimerValue += heroSpeed * Time.deltaTime * SpeedConstant;
                heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / _timerFull);
                
                heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
                if (heroTimer.TimerValue >= _timerFull)
                {
                    _freezeTick = true;
                    _activeHeroes.Add(heroTimerObject);
                }

            }

        }

        private IEnumerator AllowHeroActions()
        {
            _logicTree.AddCurrent(SortActiveHeroesByEnergy());
            
            _logicTree.AddCurrent(SetHeroActive());
            
            yield return null;
            _logicTree.EndSequence();
        }
        
        
        IEnumerator SortActiveHeroesByEnergy()
        {
           var returnList = new List<IHeroTimer>();

           foreach (var activeHero in ActiveHeroes)
           {
               returnList.Add(activeHero as IHeroTimer);
           }
            
           returnList.Sort(CompareListByATB);

           yield return returnList;
           _logicTree.EndSequence(); 
        }
        
        private int CompareListByATB(IHeroTimer i1, IHeroTimer i2)
        {
            var x = i1.TimerValue.CompareTo(i2.TimerValue);
            return x;
        }

        private IEnumerator SetHeroActive()
        {
            _activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[_activeHeroIndex] as IHeroTimer;
            
            _activeHeroLogic = activeHeroTimer.HeroLogic;

            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroActive;
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);

            yield return null;
            _logicTree.EndSequence(); 
        }

        private IEnumerator SetHeroInactive()
        {
            _activeHeroLogic.HeroStatus = _setHeroStatus.HeroInactive;
            _activeHeroLogic.HeroStatus.StatusAction(_activeHeroLogic);

            var i = _activeHeroes.Count - 1;
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
            if (_activeHeroes.Count > 0)
                _logicTree.AddCurrent(SetHeroActive());

            else
                _logicTree.AddCurrent(RunHeroTimers());

            yield return null;
            _logicTree.EndSequence();
            
        }


        public void EndTurn()
        {
            _logicTree.AddCurrent(StartNextTurn());

        }





    }
}
