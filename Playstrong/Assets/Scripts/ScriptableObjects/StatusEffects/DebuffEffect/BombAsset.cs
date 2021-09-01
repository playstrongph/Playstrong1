using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Bomb", menuName = "SO's/Status Effects/Debuffs/Bomb")]
    public class BombAsset : StatusEffectAsset
    {
        
        private int _chanceIncrease = 150;

        [SerializeField] private ScriptableObject addShockStatusEffect;
        private IHeroAction AddShockStatusEffect => addShockStatusEffect as IHeroAction;

        public override void ApplyStatusEffect(IHero hero) 
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn += DamageEffect;
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn += ShockEffect;

        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn -= DamageEffect;
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn -= ShockEffect;
        }
        
        //Subscribe to PostHeroEndTurnEvent?
        private void DamageEffect(IHero targetHero)
        {
            var counters = HeroStatusEffectReference.Counters;
            
            //var bombDamage = CasterHero.HeroLogic.HeroAttributes.Attack;
            
            //TEMP
            var bombDamage = targetHero.HeroLogic.HeroAttributes.Attack;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            if (counters <= 1)
            {
                //TODO: Replace with DealDamage SkillActionAsset.StartAction 
                logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeDirectDamage(bombDamage, 0, 0));    
            }
        }
        
        //Subscribe to PostHeroEndTurnEvent?
        private void ShockEffect(IHero targetHero)
        {
            var counters = HeroStatusEffectReference.Counters;
            
            if (counters <= 1)
                ShockLogic(targetHero);
        }
        
        private void ShockLogic(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var tempDebuffChance = 1000f;
            //temporarily increase  - higher priority than immunity (200 debuffResistance)
            targetHero.HeroLogic.OtherAttributes.DebuffChance += tempDebuffChance;
            //TEST - this might be too slow
            //logicTree.AddCurrent(ChangeDebuffChance(targetHero,tempDebuffChance));
            //TODO: AddDebuff ACtion - shock
            logicTree.AddCurrent(AddShockStatusEffect.StartAction(CasterHero,targetHero));
            //Return to original value after adding shockstatuseffect
            logicTree.AddCurrent(ChangeDebuffChance(targetHero,-tempDebuffChance));
        }
        
        

        private IEnumerator ChangeDebuffChance(IHero targetHero, float tempDebuffChance)
        {
            var logicTree = CasterHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.OtherAttributes.DebuffChance += tempDebuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }











    }
}
