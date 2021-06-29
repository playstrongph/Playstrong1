using System.Collections;
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
            var newHealth = hero.HeroLogic.HeroAttributes.Health + healAmount;
            
            //TODO: Heal Animation, temp - Damage Effect
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(HealEffect(hero, healAmount));
            
           
            
            hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            Debug.Log("Heal by: " +healAmount);
            Debug.Log("New Health: " +newHealth);
            
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
