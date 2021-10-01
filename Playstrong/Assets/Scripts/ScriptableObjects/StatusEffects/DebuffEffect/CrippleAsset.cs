using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Cripple", menuName = "SO's/Status Effects/Debuffs/Cripple")]
    public class CrippleAsset : StatusEffectAsset
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
