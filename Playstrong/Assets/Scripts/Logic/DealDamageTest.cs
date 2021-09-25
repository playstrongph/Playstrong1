using System;
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
        
        /// <summary>
        /// Called by Attack Method
        /// </summary>
        public IEnumerator DealMultiAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeSingleAttackDamage(nonCriticalDamage, criticalDamage,attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            //TODO: attackerHero.TargetsCount.TakeDamage(args)
            
            

            //logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeSingleAttackDamage(normalDamage, criticalDamage,attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        
        
       
        
        


       






     




    }
}
