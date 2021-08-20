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
    public class SetHeroEnergy : MonoBehaviour
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

        private IEnumerator SetEnergyLogic(int value)
        {
            
            
            _heroLogic.HeroAttributes.Energy = value;
            
            
            
            
            
            //_visualTree.AddCurrent(SetEnergyVisual(value));
            
            _logicTree.EndSequence();
            yield return null;
           
        }

        private IEnumerator SetEnergyVisual(int value)
        {
            _heroLogic.Hero.HeroVisual.EnergyVisual.SetEnergyTextAndBarFill(value);
            
            _visualTree.EndSequence();
            yield return null;
            
        }

        private void InitializeLocalVariables()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        
    }
}
