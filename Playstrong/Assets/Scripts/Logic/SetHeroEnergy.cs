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
            var boostEnergyResistance = _heroLogic.OtherAttributes.BoostEnergyResistance;
            var netChance = boostEnergyChance - boostEnergyResistance;
            var randomChance = Random.Range(0f, 100f);

            if (randomChance < netChance)
            {
                var newEnergyValue = currentEnergy + energyValue;
                heroTimer.SetHeroTimerValue(turnController,newEnergyValue);    
            }

            logicTree.EndSequence();
            yield return null;
           
        }
        
        //TODO: Create OtherAttribute - "DecreaseEnergyChance/Resistance"
        public void DecreaseEnergy(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
           
        }
       
        
        
        
        
        
        

        

        
        
        
    }
}
