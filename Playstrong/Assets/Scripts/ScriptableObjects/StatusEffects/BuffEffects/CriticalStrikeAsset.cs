using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "CriticalStrike", menuName = "SO's/Status Effects/Buffs/CriticalStrike")]
    public class CriticalStrikeAsset : StatusEffectAsset
    {
        [SerializeField]
        private float increaseCriticalChance = 100;

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
