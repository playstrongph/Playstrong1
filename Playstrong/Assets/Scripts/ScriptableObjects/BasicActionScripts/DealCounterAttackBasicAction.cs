using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.GameEvents;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DealCounterAttackBasicAction", menuName = "SO's/SkillActions/D/DealCounterAttackBasicAction")]
    
    public class DealCounterAttackBasicAction : BasicActionAsset
    {
        private int chanceValue = 100;
        private int resistanceValue = 1000;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += chanceValue;
            targetHero.HeroLogic.HeroEvents.EBeforeCounterAttack += TemporaryCounterResistanceIncrease;
            targetHero.HeroLogic.HeroEvents.EAfterCounterAttack += RemoveTemporaryCounterResistanceIncrease;

            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackChance -= chanceValue;
            targetHero.HeroLogic.HeroEvents.EBeforeCounterAttack -= TemporaryCounterResistanceIncrease;
            targetHero.HeroLogic.HeroEvents.EAfterCounterAttack -= RemoveTemporaryCounterResistanceIncrease;

            logicTree.EndSequence();
            yield return null;
        }
        
        

        private void TemporaryCounterResistanceIncrease(IHero targetHero,IHero dummyHero)
        {
            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance += resistanceValue;
        }
        
        private void RemoveTemporaryCounterResistanceIncrease(IHero targetHero, IHero dummyHero)
        {
            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance -= resistanceValue;
        }
        
       











    }
}
