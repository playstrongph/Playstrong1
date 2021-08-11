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
    [CreateAssetMenu(fileName = "IncreaseAttackActionAsset", menuName = "SO's/SkillActions/IncreaseAttackActionAsset")]
    
    public class IncreaseAttackActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackIncrease;

       
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            attackIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + attackIncrease;
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
