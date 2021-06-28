using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Invincible", menuName = "SO's/Status Effects/Buffs/Invincible")]
    public class InvincibleAsset : StatusEffectAsset
    {
        [Header("Invincible Modifier")]
        [SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject damageModifier;
        private IModifier DamageModifier => damageModifier as IModifier;


        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);
            
            hero.HeroLogic.TakeDamage.AddToDamageModifiersList(DamageModifier);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.TakeDamage.RemoveFromDamageModifiersList(DamageModifier);
            
        }

        private void InitializeValues(IHero hero)
        {
            _logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = hero.CoroutineTreesAsset.MainVisualTree;
        }





    }
}
