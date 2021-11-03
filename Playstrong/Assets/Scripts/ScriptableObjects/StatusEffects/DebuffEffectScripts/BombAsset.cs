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
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn += BombEffect;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EPostHeroEndTurn -= BombEffect;
        }

        private void BombEffect(IHero targetHero)
        {
            //TEST DISABLE
            /*var counters = HeroStatusEffectReference.Counters;
            var bombDamage = HeroStatusEffectReference.StatusEffectCasterHero.HeroLogic.HeroAttributes.Attack;
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            if (counters <= 1)
            {
                logicTree.AddCurrent(SkillActionAsset.StartAction(targetHero,bombDamage));    
                ShockLogic(targetHero);
            }*/
        }
        
       
        
        private void ShockLogic(IHero targetHero)
        {
            //TEST DISABLE
            /*var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var tempDebuffChance = 1000f;
            //temporarily increase  - higher priority than immunity (200 debuffResistance)
            //targetHero.HeroLogic.OtherAttributes.DebuffChance += tempDebuffChance;
            logicTree.AddCurrent(ChangeDebuffChance(targetHero, tempDebuffChance));
           
            logicTree.AddCurrent(AddShockStatusEffect.StartAction(HeroStatusEffectReference.StatusEffectCasterHero,targetHero));
           
            //Return to original value after adding shockstatuseffect
            logicTree.AddCurrent(ChangeDebuffChance(targetHero,-tempDebuffChance));*/
        }
        
        

        private IEnumerator ChangeDebuffChance(IHero targetHero, float tempDebuffChance)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.OtherAttributes.DebuffChance += tempDebuffChance;
            
            logicTree.EndSequence();
            yield return null;
        }











    }
}
