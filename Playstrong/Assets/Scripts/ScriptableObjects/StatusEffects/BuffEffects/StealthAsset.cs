using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Stealth", menuName = "SO's/Status Effects/Buffs/Stealth")]
    public class StealthAsset : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero)
        {
           base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }
    }
}
