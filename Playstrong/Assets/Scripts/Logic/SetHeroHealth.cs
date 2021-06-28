using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// All hero health value modifications should call this
    /// </summary>
    public class SetHeroHealth : MonoBehaviour, ISetHeroHealth
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetHealth(int value)
        {
            InitializeLocalVariables();
            _logicTree.AddCurrent(SetHealthLogic(value));
        }

        private IEnumerator SetHealthLogic(int value)
        {
            var baseHealth = _heroLogic.HeroAttributes.BaseHealth;

            //Clamps health value between -999 and baseHealth
            //There should be no minimum health - for damage/heal calculation purposes
            var newHealth = Mathf.Clamp(value, -999, baseHealth);

            _heroLogic.HeroAttributes.Health = newHealth;
            _visualTree.AddCurrent(SetHealthVisual(value));
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetHealthVisual(int value)
        {
            var baseHealth = _heroLogic.HeroAttributes.BaseHealth;
            var textColor = GetTextColor(baseHealth, value);
            
            _heroLogic.Hero.HeroVisual.HealthVisual.SetHealthText(value.ToString());
            _heroLogic.Hero.HeroVisual.HealthVisual.SetHealthTextColor(textColor);

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
