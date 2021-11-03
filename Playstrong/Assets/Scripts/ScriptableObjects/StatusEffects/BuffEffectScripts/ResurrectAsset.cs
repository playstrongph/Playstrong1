using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Resurrect", menuName = "SO's/Status Effects/Buffs/Resurrect")]
    public class ResurrectAsset : StatusEffectAsset
    {
       

        public override void ApplyStatusEffect(IHero hero)
        {
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

        public override void RemoveStatusEffectOnDeath(IHero hero,IHeroStatusEffect heroStatusEffect)
        {
           //Don't destroy Resurrect upon death
        }

       
        
        










    }
}
