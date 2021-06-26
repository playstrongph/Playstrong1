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
    public class SetHeroAttack : MonoBehaviour, ISetHeroAttack
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetAttack(int value)
        {
            InitializeLocalVariables();
            SetAttackLogic(value);
        }

        private IEnumerator SetAttackLogic(int value)
        {
            _heroLogic.HeroAttributes.Attack = value;

            _visualTree.AddCurrent(SetAttackVisual(value));
            
            yield return null;
            _logicTree.EndSequence();
        }

        private IEnumerator SetAttackVisual(int value)
        {
            _heroLogic.Hero.HeroVisual.AttackVisual.SetAttackText(value.ToString());
            
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
