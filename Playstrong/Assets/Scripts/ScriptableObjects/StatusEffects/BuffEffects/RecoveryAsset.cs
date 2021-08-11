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
        [SerializeField] private float percentMultiplier = 15f;

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
            
            var targetHealChance = hero.HeroLogic.OtherAttributes.HealChance;
            var targetHealResistance = hero.HeroLogic.OtherAttributes.HealResistance;
            var randomValue = Random.Range(1f, 100f);
            var netHealChance = targetHealChance - targetHealResistance;
            
            netHealChance = Mathf.Clamp(netHealChance,0, 100);
            
            
            if(randomValue <= netHealChance)
                logicTree.AddCurrent(RecoveryEffectCoroutine(hero));
        }


        private IEnumerator RecoveryEffectCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            var healMultiplier = percentMultiplier / 100f;
            var healValue = Mathf.FloorToInt(healMultiplier * hero.HeroLogic.HeroAttributes.BaseHealth);
            var newHealth = hero.HeroLogic.HeroAttributes.Health + healValue;
            
            visualTree.AddCurrent(HealVisual(hero,healValue));
            hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HealVisual(IHero hero, int value)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            hero.DamageEffect.ShowDamage(value);

            visualTree.EndSequence();
            yield return null;
        }


















    }
}
