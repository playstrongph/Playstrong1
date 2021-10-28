using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    
    /// <summary>
    /// All hero attack value modifications should call this
    /// </summary>
    public class SetHeroEnergy : MonoBehaviour, ISetHeroEnergy
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Direct access to energy change value - no checking of energy resistances
        /// </summary>
        public void SetEnergy(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SetEnergyLogic(value));
        }
        private IEnumerator SetEnergyLogic(int energyValue)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var turnController = _heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            
            heroTimer.SetHeroTimerValue(turnController,energyValue);
            
            logicTree.EndSequence();
            yield return null;
           
        }
        
        public void IncreaseEnergy(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(IncreaseEnergyLogic(value));
        }
        private IEnumerator IncreaseEnergyLogic(int energyValue)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var turnController = _heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            var currentEnergy = _heroLogic.HeroAttributes.Energy;
            var boostEnergyChance = _heroLogic.OtherAttributes.BoostEnergyChance;
            var boostEnergyResistance = _heroLogic.OtherAttributes.EnergyUpResistance;
            var netChance = boostEnergyChance - boostEnergyResistance;
            var randomChance = Random.Range(1, 101);

            if (randomChance < netChance)
            {
                var newEnergyValue = currentEnergy + energyValue;
                heroTimer.SetHeroTimerValue(turnController,newEnergyValue);    
            }

            logicTree.EndSequence();
            yield return null;
           
        }
        
        //TODO: Create OtherAttribute - "ReduceEnergyChance/Resistance"
        public void DecreaseEnergy(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(DecreaseEnergyLogic(value));
        }
        private IEnumerator DecreaseEnergyLogic(int energyValue)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            var turnController = _heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            var currentEnergy = _heroLogic.HeroAttributes.Energy;
            
            var reduceEnergyChance = _heroLogic.OtherAttributes.ReduceEnergyChance;
            var reduceEnergyResistance = _heroLogic.OtherAttributes.ReduceEnergyResistance;
            var netChance = reduceEnergyChance - reduceEnergyResistance;
            var randomChance = Random.Range(1, 101);

            if (randomChance < netChance)
            {
                var newEnergyValue = currentEnergy - energyValue;
                var newEnergy = Mathf.Max(0, newEnergyValue);
                
                heroTimer.SetHeroTimerValue(turnController,newEnergy);    
            }

            logicTree.EndSequence();
            yield return null;
           
        }
        
        
        
        
        
        

        

        
        
        
    }
}
