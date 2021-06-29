using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
    {
        private float _multiplier = 0.15f;

        public override void StartTurnStatusEffect(IHero hero)
        {
            
            InitializeValues(hero);
            
            var healAmount = Mathf.FloorToInt(hero.HeroLogic.HeroAttributes.BaseHealth * _multiplier);
            
            //TODO: Heal Animation, temp - Damage Effect
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(HealEffect(hero, healAmount));
            
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(HealLogic(hero, healAmount));

        }
        
        //TEMP
        private IEnumerator HealLogic(IHero hero, int value)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: Create HealSkill Asset and replace this
            var healAmount = Mathf.FloorToInt(hero.HeroLogic.HeroAttributes.BaseHealth * _multiplier);
            var newHealth = hero.HeroLogic.HeroAttributes.Health + healAmount;
            
            hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            logicTree.EndSequence();
            yield return null;
        }



        //TEMP
        private IEnumerator HealEffect(IHero hero, int value)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            hero.DamageEffect.ShowDamage(value);
            
            visualTree.EndSequence();
            yield return null;
        }












    }
}
