using System;
using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "DealCriticalStrike", menuName = "SO's/SkillActions/DealCriticalStrikeActionAsset")]
    
    public class DealCriticalStrikeActionAsset : SkillActionAsset
    {
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.AddCurrent(RegisterAction());
            
            LogicTree.EndSequence();
           yield return null;

        }
        
        private IEnumerator RegisterAction()
        {
            ThisHero.HeroLogic.HeroEvents.EBeforeAttacking += SetCriticalAttackIndex;
            
            LogicTree.EndSequence();
            yield return null;
        }
        
       //Test
       private void OnDisable()
       {
           ThisHero.HeroLogic.HeroEvents.EBeforeAttacking -= SetCriticalAttackIndex;
           Debug.Log("Critical Strike Action Asset Event Unsubscribe");
       }


       private void SetCriticalAttackIndex(IHero thisHero, IHero targetHero)
        {
            var criticalStrikeAttackIndex = 1;
            ThisHero.HeroLogic.BasicAttack.SetAttackIndex = criticalStrikeAttackIndex;
        }



        



      


    }
}
