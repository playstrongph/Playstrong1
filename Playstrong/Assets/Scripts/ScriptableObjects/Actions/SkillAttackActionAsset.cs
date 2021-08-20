﻿using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class SkillAttackActionAsset : SkillActionAsset
    {
        [Header("Attack Actions")] [SerializeField]
        private ScriptableObject _normalSkillAttack;
        public IHeroAction NormalSkillAttack => _normalSkillAttack as IHeroAction;
        private ScriptableObject _critricalSkillAttack;
        public IHeroAction CriticalSkillAttack => _critricalSkillAttack as IHeroAction;


        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //Pre-AttackEvents
            logicTree.AddCurrent(PreSkillAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PreAttackEvents(thisHero,targetHero));
            
            //StartAttackActions
            
            
            //Post-AttackEvents
            logicTree.AddCurrent(PostSkillAttackEvents(thisHero,targetHero));
            logicTree.AddCurrent(PostAttackEvents(thisHero,targetHero));

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetNormalOrCriticalAttack(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var criticalChance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeChance;
            var criticalResistance = thisHero.HeroLogic.OtherAttributes.CriticalStrikeResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(0f, 100f);

            var normalAttack = NormalSkillAttack;
            var criticalAttack = CriticalSkillAttack;

            netChance = Mathf.Clamp(netChance, 0f, 100f);

            /*if (randomChance <= netChance)
                return criticalAttack;
            else
            {
                return normalAttack;
            }*/
            logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator PreSkillAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeSkillAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreSkillAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PreAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostSkillAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterSkillAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostSkillAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        

       



      


    }
}
