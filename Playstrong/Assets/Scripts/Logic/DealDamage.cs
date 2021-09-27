using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour, IDealDamage
    {
        private IHeroLogic _heroLogic;
        
        [SerializeField]
        private int otherAttackDamage;

        public int OtherAttackDamage
        {
            get => otherAttackDamage;
            set => otherAttackDamage = value;
        }
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public IEnumerator DealDirectDamage(IHero targetHero, int directDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var criticalDamage = 0;
            var penetrateArmorChance = (int)_heroLogic.OtherAttributes.PenetrateArmorChance;
            
            //Original
            //logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeDirectDamage(directDamage,criticalDamage,penetrateChance));
            
            //TEST
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeDirectDamage(directDamage,criticalDamage,penetrateArmorChance));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherDamageMultiplier = attackerHero.HeroLogic.OtherAttributes.OtherDamageMultiplier;   //Example - Hero takes additional X% damage - e.g. Target debuff
            var attackDamage = attackPower + OtherAttackDamage;
            var nonCriticalDamage = Mathf.CeilToInt(otherDamageMultiplier*attackDamage/100);
            var normalDamage = attackDamage + nonCriticalDamage;
            var criticalDamage = Mathf.CeilToInt(criticalFactor * normalDamage);
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeSingleAttackDamage(normalDamage, criticalDamage,attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealMultipleAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherDamageMultiplier = attackerHero.HeroLogic.OtherAttributes.OtherDamageMultiplier;   //Example - Hero takes additional X% damage - e.g. Target debuff

            var attackDamage = attackPower + OtherAttackDamage;
            var nonCriticalDamage = Mathf.CeilToInt(otherDamageMultiplier*attackDamage/100);
            
            var normalDamage = attackDamage + nonCriticalDamage;
            
            var criticalDamage = Mathf.CeilToInt(criticalFactor * normalDamage);
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeMultipleAttackDamage(normalDamage, criticalDamage,attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
       
        
        


       






     




    }
}
