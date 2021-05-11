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
            //_logicTree.Start();
            //_logicTree.AddRoot(RunTick());
            
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

            //TODO: allowHeroActions
            
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
