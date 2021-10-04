using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Stun", menuName = "SO's/Status Effects/Debuffs/Stun")]
    public class StunAsset : StatusEffectAsset
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
