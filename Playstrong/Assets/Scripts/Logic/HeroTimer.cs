using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroTimer : MonoBehaviour, IHeroTimer
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroLogic))]
        private Object _heroLogic;
        public IHeroLogic HeroLogic => _heroLogic as IHeroLogic;
        
        [SerializeField] 
        private float _timerValue;

        public float TimerValue
        {
            get => _timerValue;
            set => _timerValue = value;
        }

        [SerializeField]
        private float _timerValuePercentage;

        public float TimerValuePercentage
        {
            get => _timerValuePercentage;
            set => _timerValuePercentage = value;
        }

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>() as Object;
        }
        
        public void ResetHeroTimer()
        {
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;
            
           TimerValue = 0;
           TimerValuePercentage = 0;
           HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(TimerValuePercentage);
           
           heroEnergyVisual.SetEnergyTextAndBarFill((int)TimerValuePercentage);
           
        }

        public void UpdateHeroTimer(ITurnController turnController)
        {
            var speedConstant = turnController.SpeedConstant;
            var timerFull = turnController.TimerFull;
            var activeHeroes = turnController.ActiveHeroes;

            var heroSpeed = HeroLogic.HeroAttributes.Speed;
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;
            
            TimerValue += heroSpeed * Time.deltaTime * speedConstant;
            TimerValuePercentage = Mathf.FloorToInt(TimerValue * 100 / timerFull);
            
            
            HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(TimerValuePercentage);
            heroEnergyVisual.SetEnergyTextAndBarFill((int)TimerValuePercentage);
                
            if (TimerValue >= timerFull)
            {
                turnController.FreezeTimers = true;
                activeHeroes.Add(this as Object);
            }
        }

        public void SetHeroTimerValue(ITurnController turnController, int energyValue)
        {
            var timerFull = turnController.TimerFull;
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;
            var activeHeroes = turnController.ActiveHeroes;
            
            var timerValueConvert = energyValue * timerFull / 100f;

            TimerValue = timerValueConvert;
            TimerValue = Mathf.Max(0f, TimerValue);  //clamps minimum of Timervalue to zero. 
            TimerValuePercentage = Mathf.FloorToInt(TimerValue * 100 / timerFull);
            
            HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(TimerValuePercentage);
            heroEnergyVisual.SetEnergyTextAndBarFill((int)TimerValuePercentage);
            
            if (TimerValue >= timerFull)
            {
                turnController.FreezeTimers = true;
                
                //TEMP till there is a better implem
                if(!activeHeroes.Contains(this as Object)) 
                    activeHeroes.Add(this as Object);

                turnController.SortHeroesByEnergy.SortByEnergy();
            }
            
            if (TimerValue < timerFull)
            {
                //TEMP till there is a better implem
                if(activeHeroes.Contains(this as Object)) 
                    activeHeroes.Remove(this as Object);
                
                turnController.SortHeroesByEnergy.SortByEnergy();
            }
        }
        
        
        

    }
}
