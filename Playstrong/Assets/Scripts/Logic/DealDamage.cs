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

        [SerializeField] private int normalAttackDamage;

        private int NormalAttackDamage
        {
            get => normalAttackDamage;
            set => normalAttackDamage = value;
        }

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
        
        public IEnumerator DealAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherDamageMultiplier = attackerHero.HeroLogic.OtherAttributes.OtherDamageMultiplier;   //Example - Hero takes additional X% damage - e.g. Target debuff
            var totalDamageMultiplier = criticalFactor + otherDamageMultiplier;
            
            NormalAttackDamage = attackPower + OtherAttackDamage;
            
            var totalEnhancedDamage = Mathf.CeilToInt(totalDamageMultiplier * NormalAttackDamage);
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeAttackDamage(NormalAttackDamage, totalEnhancedDamage,attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealDirectDamage(IHero targetHero, int normalDamage, int penetrateChance)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var criticalDamage = 0;
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeDirectDamage(normalDamage,criticalDamage,penetrateChance));
            
            logicTree.EndSequence();
            yield return null;
        }
        
       
        
        


       






     




    }
}
