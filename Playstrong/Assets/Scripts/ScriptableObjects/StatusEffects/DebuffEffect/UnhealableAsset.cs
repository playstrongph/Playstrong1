using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Unhealable", menuName = "SO's/Status Effects/Debuffs/Unhealable")]
    public class UnhealableAsset : StatusEffectAsset
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
