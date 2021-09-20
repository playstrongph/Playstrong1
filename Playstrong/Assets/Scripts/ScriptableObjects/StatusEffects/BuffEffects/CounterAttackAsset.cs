using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "CounterAttack", menuName = "SO's/Status Effects/Buffs/CounterAttack")]
    public class CounterAttackAsset : StatusEffectAsset
    {
        [SerializeField]
        private float counterattackValue = 100f;

        public override void ApplyStatusEffect(IHero hero)
        {
            EffectValue = counterattackValue;
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }


        
        
        







    }
}
