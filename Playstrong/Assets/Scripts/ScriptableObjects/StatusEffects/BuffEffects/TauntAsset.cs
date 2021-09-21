using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Taunt", menuName = "SO's/Status Effects/Buffs/Taunt")]
    public class TauntAsset : StatusEffectAsset
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
