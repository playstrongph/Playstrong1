﻿using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "DecreaseCriticalChance", menuName = "SO's/SkillActions/DecreaseCriticalChance")]
    
    public class DecreaseCriticalChanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int decreaseCriticalChance;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            decreaseCriticalChance = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= decreaseCriticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}