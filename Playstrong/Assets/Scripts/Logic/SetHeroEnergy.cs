using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// All hero attack value modifications should call this
    /// </summary>
    public class SetHeroEnergy : MonoBehaviour, ISetHeroEnergy
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetEnergy(int value)
        {
            InitializeLocalVariables();
            _logicTree.AddCurrent(SetEnergyLogic(value));
        }

        private IEnumerator SetEnergyLogic(int energyValue)
        {
            var turnController = _heroLogic.Hero.LivingHeroes.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            
            heroTimer.SetHeroTimerValue(turnController,energyValue);
            
            _logicTree.EndSequence();
            yield return null;
           
        }

        

        private void InitializeLocalVariables()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        
    }
}
