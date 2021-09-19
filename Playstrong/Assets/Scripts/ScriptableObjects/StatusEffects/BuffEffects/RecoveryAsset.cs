 using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
 using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
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
