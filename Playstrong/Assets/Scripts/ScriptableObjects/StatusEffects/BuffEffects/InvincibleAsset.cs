using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Invincible", menuName = "SO's/Status Effects/Buffs/Invincible")]
    public class InvincibleAsset : StatusEffectAsset
    {

        [SerializeField] private int reductionValue = 100;
        public override void ApplyStatusEffect(IHero hero)
        {
            var otherAttributes = hero.HeroLogic.OtherAttributes;
            otherAttributes.DamageReduction += reductionValue;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var otherAttributes = hero.HeroLogic.OtherAttributes;
            otherAttributes.DamageReduction -= reductionValue;
        }

       





    }
}
