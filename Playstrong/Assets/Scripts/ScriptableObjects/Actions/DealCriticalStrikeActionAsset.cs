using System;
using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "DealCriticalStrike", menuName = "SO's/SkillActions/DealCriticalStrikeActionAsset")]
    
    public class DealCriticalStrikeActionAsset : SkillActionAsset
    {

        [SerializeField] private float criticalChance = 100f;
        
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            SetCriticalAttackIndex();
            
           LogicTree.EndSequence();
           yield return null;

        }

        private void SetCriticalAttackIndex()
        {
            //Original
            //var criticalStrikeAttackIndex = 1;
            //ThisHero.HeroLogic.BasicAttack.SetAttackIndex = criticalStrikeAttackIndex;
            
            //TEST
            //ThisHero.HeroLogic.HeroEvents.EBeforeAttacking += IncreaseCriticalChance;

            ThisHero.HeroLogic.HeroAttributes.CriticalChance += criticalChance;
            
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking += RemoveCriticalChanceIncrease;
        }

        private void IncreaseCriticalChance(IHero thisHero, IHero dummyHero)
        {
            thisHero.HeroLogic.HeroAttributes.CriticalChance += criticalChance;
            ThisHero.HeroLogic.HeroEvents.EBeforeAttacking -= IncreaseCriticalChance;
        }
        
        private void RemoveCriticalChanceIncrease(IHero thisHero, IHero dummyHero)
        {
            thisHero.HeroLogic.HeroAttributes.CriticalChance -= criticalChance;
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking -= RemoveCriticalChanceIncrease;
        }
        
        
        
        










    }
}
