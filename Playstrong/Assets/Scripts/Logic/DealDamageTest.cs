using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamageTest : MonoBehaviour, IDealDamageTest
    {
        
        
        public IEnumerator DealMultiAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));

            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeMultiAttackDamage(nonCriticalDamage, criticalDamage,attackerHero));
            
            logicTree.AddCurrent(AfterHeroDealsSkillDamage(attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeSingleAttackDamage(nonCriticalDamage, criticalDamage,attackerHero));
            
            logicTree.AddCurrent(AfterHeroDealsSkillDamage(attackerHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// For non-attack damage abilities in skills.  Example - whenever you are attacked, deal 5 damage to your attacker.
        /// </summary>
        public IEnumerator DealNonAttackSkillDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var ignoreArmorChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance;
            
            
            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonAttackSkillDamage(nonCriticalDamage, ignoreArmorChance));

            logicTree.AddCurrent(AfterHeroDealsSkillDamage(attackerHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For damage sources other than skills - status effects, weapons, etc.
        /// </summary>
        public IEnumerator DealNonSkillDamage(IHero targetHero, int nonSkillDamage, float ignoreArmorChance)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Non Skill Damage: " +nonSkillDamage);
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonSkillDamage(nonSkillDamage, ignoreArmorChance));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //Events 
        private IEnumerator BeforeHeroDealsSkillDamage(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeHeroDealsSkillDamage(thisHero);

            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator AfterHeroDealsSkillDamage(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterHeroDealsSkillDamage(thisHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator BeforeHeroDealsNonSkillDamage(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeHeroDealsNonSkillDamage(thisHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AfterHeroDealsNonSkillDamage(IHero thisHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterHeroDealsNonSkillDamage(thisHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        


       






     




    }
}
