﻿using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackBasicAction", menuName = "SO's/BasicActions/IncreaseAttack")]
    
    public class IncreaseAttackBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatAttack;
        [SerializeField] private int percentAttack;

        private int changeAttackValue;

        public override IEnumerator TargetAction(IHero targetHero,float value)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + (int)value;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            SetChangeAttackValue(targetHero);

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack + changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var newAttackValue = targetHero.HeroLogic.HeroAttributes.Attack - changeAttackValue;
            
            targetHero.HeroLogic.SetHeroAttack.SetAttack(newAttackValue);

            logicTree.EndSequence();
            yield return null;
        }


        private void SetChangeAttackValue(IHero hero)
        {
            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;
            changeAttackValue = Mathf.FloorToInt(baseAttack * percentAttack/100) + flatAttack;
        }

      










    }
}