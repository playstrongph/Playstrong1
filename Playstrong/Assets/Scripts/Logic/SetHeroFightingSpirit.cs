using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Logic
{
    
   
    public class SetHeroFightingSpirit : MonoBehaviour, ISetHeroFightingSpirit
    {
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void SetFightingSpirit(int value)
        {
            InitializeLocalVariables();
            _logicTree.AddCurrent(SetFightingSpiritLogic(value));
        }

        private IEnumerator SetFightingSpiritLogic(int value)
        {
            
            var newFightingSpirit = Mathf.Clamp(value, 0, 99999);

            _heroLogic.OtherAttributes.FightingSpirit = newFightingSpirit;
            
            _visualTree.AddCurrent(SetFightingSpiritVisual(newFightingSpirit));
            
            _logicTree.EndSequence();
            yield return null;
            
        }

        private IEnumerator SetFightingSpiritVisual(int value)
        {
            Debug.Log("SetFightingSpiritVisual " +value);
            _heroLogic.Hero.HeroVisual.FightingSpiritVisual.SetFightingSpiritText(value);

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
