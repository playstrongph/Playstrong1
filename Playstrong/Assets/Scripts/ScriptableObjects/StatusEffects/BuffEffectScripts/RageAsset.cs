using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Rage", menuName = "SO's/Status Effects/UniqueEffects/Rage")]
    public class RageAsset : StatusEffectAsset
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
