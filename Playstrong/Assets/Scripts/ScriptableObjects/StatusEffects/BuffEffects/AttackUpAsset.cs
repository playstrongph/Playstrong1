using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset
    {
        private int _attackIncrease;
        private float _multiplier = 0.5f;
        
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        
        public override void ApplyStatusEffect(IHero hero)
        {
            InitializeValues(hero);

            //TODO: HeroLogic: SetHeroAttackValue attached to Herologic 
            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack + _attackIncrease;
            hero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);
            
            //hero.HeroLogic.HeroAttributes.Attack += _attackIncrease;
            //hero.HeroVisual.AttackVisual.SetAttackText(hero.HeroLogic.HeroAttributes.Attack.ToString());
                        
            
            Debug.Log("Attack Up Buff");       
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack - _attackIncrease;
            hero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);
            
            //hero.HeroLogic.HeroAttributes.Attack -= _attackIncrease;
            //hero.HeroVisual.AttackVisual.SetAttackText(hero.HeroLogic.HeroAttributes.Attack.ToString());
            
            Debug.Log("Unapply Attack Up Buff");       
        }

        private void InitializeValues(IHero hero)
        {
            _logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = hero.CoroutineTreesAsset.MainVisualTree;

            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            _attackIncrease = Mathf.FloorToInt(_multiplier * baseAttack);
        }





    }
}
