using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Immortality", menuName = "SO's/Status Effects/Buffs/Immortality")]
    public class ImmortalityAsset : StatusEffectAsset
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
