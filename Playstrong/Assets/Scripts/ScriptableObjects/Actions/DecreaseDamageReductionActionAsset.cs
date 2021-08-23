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
    [CreateAssetMenu(fileName = "DecreaseDamageReductionAction", menuName = "SO's/SkillActions/DecreaseDamageReductionAction")]
    
    
    
    public class DecreaseDamageReductionActionAsset : SkillActionAsset
    {
        [SerializeField] private int damageReductionValue;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            damageReductionValue = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.DamageReduction -= damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
