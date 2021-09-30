using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "DefenseBreak", menuName = "SO's/Status Effects/Debuffs/DefenseBreak")]
    public class DefenseBreakAsset : StatusEffectAsset
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
