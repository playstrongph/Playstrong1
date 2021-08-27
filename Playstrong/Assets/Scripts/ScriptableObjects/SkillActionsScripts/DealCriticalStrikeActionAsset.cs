using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
            ThisHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChance;
            
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking += RemoveCriticalChanceIncrease;
        }

        private void RemoveCriticalChanceIncrease(IHero thisHero, IHero dummyHero)
        {
            thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= criticalChance;
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking -= RemoveCriticalChanceIncrease;
        }
        
        
        
        










    }
}
