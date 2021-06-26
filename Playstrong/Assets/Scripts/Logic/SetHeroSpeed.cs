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
    public class SetHeroSpeed : MonoBehaviour, ISetHeroSpeed
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetSpeed(int value)
        {
            InitializeLocalVariables();
            _logicTree.AddCurrent(SetSpeedLogic(value));
        }

        private IEnumerator SetSpeedLogic(int value)
        {
            _heroLogic.HeroAttributes.Speed = value;
            _visualTree.AddCurrent(SetSpeedVisual(value));
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetSpeedVisual(int value)
        {
            var baseSpeed = _heroLogic.HeroAttributes.BaseSpeed;
            var textColor = GetTextColor(baseSpeed, value);
            
            _heroLogic.Hero.HeroVisual.EnergyVisual.SetEnergyTextColor(textColor);
            
            yield return null;
            _visualTree.EndSequence();
        }

        private void InitializeLocalVariables()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;

        }
        
        private Color GetTextColor(int baseValue, int value)
        {
            if(value>baseValue)
                return Color.green;
            else if (value == baseValue)
                return Color.white;
            else if(value < baseValue)
                return Color.red;
            else
                return Color.white;
            
        }
    }
}
