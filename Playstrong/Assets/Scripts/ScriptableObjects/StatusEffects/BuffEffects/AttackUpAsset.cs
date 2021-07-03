using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset
    {
        [SerializeField]
        private float _multiplier;
        
        private int _attackIncrease;
        
        
        
        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);
            ComputeAttackIncrease();
             
            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack + _attackIncrease;
            hero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack - _attackIncrease;
            hero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);
        }

        private void ComputeAttackIncrease()
        {
            var baseAttack = Hero.HeroLogic.HeroAttributes.BaseAttack;
            _attackIncrease = Mathf.FloorToInt(_multiplier * baseAttack);
        }





    }
}
