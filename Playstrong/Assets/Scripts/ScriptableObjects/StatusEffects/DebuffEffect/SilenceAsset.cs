using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Silence", menuName = "SO's/Status Effects/Debuffs/Silence")]
    public class SilenceAsset : StatusEffectAsset
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
