using System.Collections;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
using ScriptableObjects.Actions;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Recovery", menuName = "SO's/Status Effects/Buffs/Recovery")]
    public class RecoveryAsset : StatusEffectAsset
    {
        [SerializeField] private float healthMultiplier;

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn += RecoveryEffect;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn -= RecoveryEffect;
        }

        private void RecoveryEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(RecoveryEffectCoroutine(hero));
        }


        private IEnumerator RecoveryEffectCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            visualTree.AddCurrent(HealVisual(hero));

            var newHealth = hero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healthMultiplier* hero.HeroLogic.HeroAttributes.BaseHealth);
            
            hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            logicTree.EndSequence();
            yield return null;
        }


        //TEMP - need to change animation to heal animation
        private IEnumerator HealVisual(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            hero.DamageEffect.ShowDamage(Mathf.FloorToInt(healthMultiplier* hero.HeroLogic.HeroAttributes.BaseHealth));

            visualTree.EndSequence();
            yield return null;
        }
















    }
}
