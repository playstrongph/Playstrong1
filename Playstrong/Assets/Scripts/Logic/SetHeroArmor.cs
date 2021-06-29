using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// All hero armor value modifications should call this
    /// </summary>
    public class SetHeroArmor : MonoBehaviour, ISetHeroArmor
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetArmor(int value)
        {
            InitializeLocalVariables();
            _logicTree.AddCurrent(SetArmorLogic(value));
        }

        private IEnumerator SetArmorLogic(int value)
        {
            
            var newArmor = Mathf.Clamp(value, 0, 99999);

            _heroLogic.HeroAttributes.Armor = newArmor;
            
            _visualTree.AddCurrent(SetArmorVisual(newArmor));
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetArmorVisual(int value)
        {
            _heroLogic.Hero.HeroVisual.ArmorVisual.SetArmorText(value);
            
            yield return null;
            _visualTree.EndSequence();
        }

        private void InitializeLocalVariables()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }
        
        
    }
}
