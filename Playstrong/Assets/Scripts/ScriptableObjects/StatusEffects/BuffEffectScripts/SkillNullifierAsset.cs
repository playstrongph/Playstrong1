using System.Collections;
using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "SkillNullifier", menuName = "SO's/Status Effects/Buffs/SkillNullifier")]
    public class SkillNullifierAsset : StatusEffectAsset
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
