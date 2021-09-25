﻿using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamageTest : MonoBehaviour, IDealDamageTest
    {
        private IHeroLogic _heroLogic;

        //TODO: This should be only OtherDamage
        /// <summary>
        /// Damage dealt by status effects and equipment
        /// Should be dealt outside (Pre or Post Attack Damage)
        /// If dealt within attack damage, shall be absorbed in AdditionalAttackDamage
        /// </summary>
        public int OtherDamage { get; set; }
        /// <summary>
        /// Additional damage component dealt by 1st, 2nd, and 3rd skill on top of attack power
        /// Example: deal additional 10% max HP as damage, deal 150% attack damage, etc.
        /// Depending on a skill, this can be a list if there are multiple "AdditionalAttackDamages" 
        /// </summary>
        public int AdditionalAttackDamage { get; set; }
        
        /// <summary>
        /// Damage dealt by critical strike and calculated based on critical damage attribute
        ///  </summary>
        public int CriticalDamage { get; set; }
  

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        
        public IEnumerator DealMultiAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: DealDamage Multi Event here

            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeMultiAttackDamage(nonCriticalDamage, criticalDamage,attackerHero));
            
            //TODO: DealDamage Multi Event here

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TODO: DealDamage Single Event here
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeSingleAttackDamage(nonCriticalDamage, criticalDamage,attackerHero));
            
            //TODO: DealDamage Single Event here
            
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
            
            //TODO: SkillDamage PreEvent
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonAttackSkillDamage(nonCriticalDamage, ignoreArmorChance));
            
            //TODO: SkillDamage PostEvent
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For damage sources other than skills - status effects, weapons, etc.
        /// </summary>
        public IEnumerator DealNonAttackOtherDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var ignoreArmorChance = attackerHero.HeroLogic.OtherAttributes.PenetrateArmorChance;
            
            //TODO: SkillDamage PreEvent
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonAttackOtherDamage(nonCriticalDamage, ignoreArmorChance));
            
            //TODO: SkillDamage PreEvent
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
         
       
        
        


       






     




    }
}
