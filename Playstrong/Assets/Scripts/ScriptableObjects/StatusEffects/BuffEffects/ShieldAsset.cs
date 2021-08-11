﻿using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Shield", menuName = "SO's/Status Effects/Buffs/Shield")]
    public class ShieldAsset : StatusEffectAsset
    {
        
        [SerializeField] private int reductionValue = 50;


        public override void ApplyStatusEffect(IHero hero)
        {
            var otherAttributes = hero.HeroLogic.OtherAttributes;
            otherAttributes.DamageReduction += reductionValue;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var otherAttributes = hero.HeroLogic.OtherAttributes;
            otherAttributes.DamageReduction -= reductionValue;
        }






    }
}
