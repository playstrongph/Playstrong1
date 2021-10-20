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
            base.ApplyStatusEffect(hero);   
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero); 
               
        }

    }
}
