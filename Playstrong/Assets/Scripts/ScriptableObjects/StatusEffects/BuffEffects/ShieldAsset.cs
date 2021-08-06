using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Shield", menuName = "SO's/Status Effects/Buffs/Shield")]
    public class ShieldAsset : StatusEffectAsset
    {
        [Header("Shield Modifier")]
        [SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject damageModifier;
        private IModifier DamageModifier => damageModifier as IModifier;

        //TEST
        [SerializeField] private float _damageModifier2 = 0.5f;
        private float DamageModifier2 => _damageModifier2;
        //TEST END


        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);
            
            //hero.HeroLogic.TakeDamage.AddToDamageModifiersList(DamageModifier);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            //hero.HeroLogic.TakeDamage.RemoveFromDamageModifiersList(DamageModifier);
            
        }






    }
}
