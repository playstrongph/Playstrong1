﻿using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class TurnController : MonoBehaviour, ITurnController
    {

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
        public ICoroutineTree LogicTree
        {
            get => _logicTree;
            set => _logicTree = value;
        }
        
        private ICoroutineTree _visualTree;
        public ICoroutineTree VisualTree
        {
            get => _visualTree;
            set => _visualTree = value;
        }

        private IBattleSceneManager _battleSceneManager;
        
        
        public void StartTick()
        {
            LogicTree.AddCurrent(RunTick());
        }

        private IEnumerator RunTick()
        {
            _freezeTick = false;

            while (!_freezeTick)
            {
                yield return null;
                UpdateHeroTimers();
            }

            LogicTree.AddCurrent(AllowHeroActions());
            
            yield return null;
            LogicTree.EndSequence();
        }


        private void UpdateHeroTimers()
        {
           
            foreach (var heroTimerObject in _heroTimers)
            {
                var heroTimer = heroTimerObject as IHeroTimer;
                var heroSpeed = heroTimer.HeroLogic.HeroAttributes.Speed;
                var heroEnergyVisual = heroTimer.HeroLogic.Hero.HeroVisual.EnergyVisual;

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
            LogicTree.AddCurrent(SortActiveHeroesByEnergy());
            
            LogicTree.AddCurrent(SetActiveHero());
            
            yield return null;
            LogicTree.EndSequence();
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
           LogicTree.EndSequence(); 
        }
        
        private int CompareListByATB(IHeroTimer i1, IHeroTimer i2)
        {
            var x = i1.TimerValue.CompareTo(i2.TimerValue);
            return x;
        }

        private IEnumerator SetActiveHero()
        {
            var activeHeroIndex = ActiveHeroes.Count - 1;
            var activeHeroTimer = ActiveHeroes[activeHeroIndex] as IHeroTimer;
            var activeHeroLogic = activeHeroTimer.HeroLogic;

            LogicTree.AddCurrent(activeHeroLogic.SetHeroActive.SetActive(_logicTree));
            
             yield return null;
             LogicTree.EndSequence(); 
        }



        public void EndTurn()
        {
            //TODO: NextActiveHero
            
            //TEMP
            _freezeTick = false;
            _activeHeroes.Clear();
            StartTick();
            //TEMP

        }





    }
}
