using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "SO's/Status Effects/Debuffs/Sleep")]
    public class SleepAsset : StatusEffectAsset
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
