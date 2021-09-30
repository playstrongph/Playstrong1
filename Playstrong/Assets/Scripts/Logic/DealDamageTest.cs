using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamageTest : MonoBehaviour, IDealDamageTest
    {

        private IHeroLogic _thisHeroLogic;

        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator DealMultiAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var finalNonCriticalDamage = ComputeMultipleAttackNonCriticalDamage(nonCriticalDamage);
            var finalCriticalDamage = ComputeMultipleAttackCriticalDamage(criticalDamage);
            
            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));

            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeMultiAttackDamage(finalNonCriticalDamage, finalCriticalDamage,attackerHero));
            
            logicTree.AddCurrent(AfterHeroDealsSkillDamage(attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var finalNonCriticalDamage = ComputeSingleAttackNonCriticalDamage(nonCriticalDamage);
            var finalCriticalDamage = ComputeSingleAttackCriticalDamage(criticalDamage);
            
            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeSingleAttackDamage(finalNonCriticalDamage, finalCriticalDamage,attackerHero));
            
            logicTree.AddCurrent(AfterHeroDealsSkillDamage(attackerHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// For non-attack damage abilities in skills.  Example - whenever you are attacked, deal 5 damage to your attacker.
        /// </summary>
        public IEnumerator DealNonAttackSkillDamage(IHero attackerHero, IHero targetHero, int nonAttackSkillDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var ignoreArmorChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance;
            var finalNonAttackSkillDamage = ComputeNonAttackSkillDamage(nonAttackSkillDamage);
            

            logicTree.AddCurrent(BeforeHeroDealsSkillDamage(attackerHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonAttackSkillDamage(finalNonAttackSkillDamage, ignoreArmorChance));

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
            var finalNonSkillDamage = ComputeNonSkillDamage(nonSkillDamage);
            
            Debug.Log("Non Skill Damage: " +nonSkillDamage);
            
            
            logicTree.AddCurrent(BeforeHeroDealsNonSkillDamage(_thisHeroLogic.Hero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonSkillDamage(finalNonSkillDamage, ignoreArmorChance));
            
            logicTree.AddCurrent(AfterHeroDealsNonSkillDamage(_thisHeroLogic.Hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //AUXILIARY METHODS
        
        
        //SINGLE ATTACKS
        private int ComputeMultipleAttackNonCriticalDamage(int nonCriticalDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealMultipleAttackDamageReduction = 0 / 100f;
            var dealSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1-dealMultipleAttackDamageReduction)*(1 - dealAllDamageReduction) *(1-dealSkillDamageReduction)* (nonCriticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        private int ComputeMultipleAttackCriticalDamage(int criticalDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealMultipleAttackDamageReduction = 0 / 100f;
            var dealSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1-dealMultipleAttackDamageReduction)*(1 - dealAllDamageReduction) *(1-dealSkillDamageReduction)* (criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        //MULTI ATTACKS
        private int ComputeSingleAttackNonCriticalDamage(int nonCriticalDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealSingleAttackDamageReduction = 0 / 100f;
            var dealSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1-dealSingleAttackDamageReduction)*(1 - dealAllDamageReduction) *(1-dealSkillDamageReduction)* (nonCriticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        private int ComputeSingleAttackCriticalDamage(int criticalDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealSingleAttackDamageReduction = 0 / 100f;
            var dealSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1-dealSingleAttackDamageReduction)*(1 - dealAllDamageReduction) *(1-dealSkillDamageReduction)* (criticalDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        
        //NON SKILL ATTACK and NON SKILL DAMAGE
        private int ComputeNonAttackSkillDamage(int nonAttackSkillDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1 - dealAllDamageReduction) *(1-dealSkillDamageReduction)* (nonAttackSkillDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }
        
        private int ComputeNonSkillDamage(int nonAttackSkillDamage)
        {
            //var allDamageReduction = _thisHeroLogic.OtherAttributes.DamageReduction / 100;
            //var multipleAttackDamageReduction = _thisHeroLogic.OtherAttributes.MultipleAttackDamageReduction / 100;
            //var skillDamageReduction = _thisHeroLogic.OtherAttributes.SkillDamageReduction / 100;
            
            //TODO: Create in OtherAttributes and replace the zeroes
            var dealAllDamageReduction = 0 / 100f;
            var dealNonSkillDamageReduction =  0/ 100f;
            
            
            var floatFinalDamage = (1 - dealAllDamageReduction) *(1-dealNonSkillDamageReduction)* (nonAttackSkillDamage);

            var finalDamage = Mathf.CeilToInt(floatFinalDamage);

            return finalDamage;
        }




        //EVENTS 
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
