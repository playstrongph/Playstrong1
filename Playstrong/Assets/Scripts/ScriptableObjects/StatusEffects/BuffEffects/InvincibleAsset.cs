using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Invincible", menuName = "SO's/Status Effects/Buffs/Invincible")]
    public class InvincibleAsset : StatusEffectAsset
    {

        [SerializeField] private float reductionValue = 100f;
        public override void ApplyStatusEffect(IHero hero)
        {
            EffectValue = reductionValue;
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }

       





    }
}
