using System.Collections;
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
            set => _logicTree = value;
        }
        
        private ICoroutineTree _visualTree;
        public ICoroutineTree VisualTree
        {
            set => _visualTree = value;
        }
        
        
        public void StartTick()
        {
            _logicTree.AddCurrent(RunTick());
        }

        private IEnumerator RunTick()
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

                heroTimer.TimerValue += heroSpeed * Time.deltaTime * SpeedConstant;
                heroTimer.TimerValuePercentage = Mathf.FloorToInt(heroTimer.TimerValue * 100 / _timerFull);
                
                heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                
                if (heroTimer.TimerValue >= _timerFull)
                {
                    _freezeTick = true;
                    _activeHeroes.Add(heroTimerObject);
                    
                    //TEMP
                    heroTimer.TimerValue = 0;
                    heroTimer.TimerValuePercentage = 0;
                    heroEnergyVisual.SetEnergyTextAndBarFill((int)heroTimer.TimerValuePercentage);
                    //TEMP
                }

            }

        }

        private IEnumerator AllowHeroActions()
        {
            _logicTree.AddCurrent(SortActiveHeroesByEnergy());
            
            //_logicTree.AddCurrent(SetActiveHero());
            
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
        
        
        
        



        public void EndTurn()
        {
            //TEMP
            _freezeTick = false;
            _activeHeroes.Clear();
            StartTick();
            //TEMP

        }





    }
}
