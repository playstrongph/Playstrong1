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
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            SetCriticalAttackIndex();
            
           LogicTree.EndSequence();
           yield return null;

        }

        private void SetCriticalAttackIndex()
        {
            var criticalStrikeAttackIndex = 1;
            ThisHero.HeroLogic.BasicAttack.SetAttackIndex = criticalStrikeAttackIndex;
            Debug.Log("Set Attack Index: "+ThisHero.HeroLogic.BasicAttack.SetAttackIndex);
        }



        



      


    }
}
