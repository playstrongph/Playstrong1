using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.DamageAttributeMultiple;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "CurseTest", menuName = "SO's/Status Effects/Debuffs/CurseTest")]
    public class CurseAsset : StatusEffectAsset
    {
        
        public override void ApplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.ApplyStatusEffect(allyHero);   
            }
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            foreach (var allyHero in hero.AllAllyHeroes)
            {
                base.UnapplyStatusEffect(allyHero);   
            }
               
        }

    }
}
