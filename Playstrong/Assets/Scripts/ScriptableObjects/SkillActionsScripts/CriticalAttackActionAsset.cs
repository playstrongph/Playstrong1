using System.Collections;
using Interfaces;
using ScriptableObjects.AnimationSOscripts;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "CriticalAttackActionAsset", menuName = "SO's/SkillActions/CriticalAttackActionAsset")]
    
    public class CriticalAttackActionAsset : SkillActionAsset
    {
        [Header("Game Animation Asset")]
        [SerializeField] private ScriptableObject attackAnimation;
        private IGameAnimations AttackAnimation => attackAnimation as IGameAnimations;
        
        private float _preAttackValue;
        private int _finalAttackValue;
        private float _criticalMultiplier;

        private float _intervalDelay = 1f;
       
        [Header("Attack Target Type")] [SerializeField]
        private ScriptableObject attackTargetType;
        private IAttackTargetTypeAsset AttackTargetType => attackTargetType as IAttackTargetTypeAsset;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(PreCriticalStrikeEvents(thisHero,targetHero));

            logicTree.AddCurrent(AttackHero(thisHero,targetHero));
            
            logicTree.AddCurrent(PostCriticalStrikeEvents(thisHero,targetHero));
            

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator PreCriticalStrikeEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeCriticalStrike(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreCriticalStrike(targetHero, thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostCriticalStrikeEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.AfterCriticalStrike(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PostCriticalStrike(targetHero, thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var dealDamage = targetHero.HeroLogic.DealDamage;
            var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = thisHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier/100;

            logicTree.AddCurrent(AttackHeroLogic(thisHero,targetHero));
            
            //TODO: AttackTargetType.DealAttackDamage
            //TEST
            logicTree.AddCurrent(AttackTargetType.DealAttackDamage(dealDamage,thisHero, targetHero, attackPower, criticalFactor));
            
            //TEST - comment out
            //logicTree.AddCurrent(dealDamage.DealAttackDamage(thisHero, targetHero,attackPower, criticalFactor));
            
            logicTree.AddCurrent(AttackInterval(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AttackHeroLogic(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
            //visualTree.AddCurrent(AttackHeroVisual(thisHero,targetHero));
            
            visualTree.AddCurrent(AttackAnimation.StartAnimation(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator AttackInterval(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
            //Inserts delay in seconds before calling visualTree.EndSequence()
            visualTree.AddCurrentWait(_intervalDelay, visualTree);
            
            logicTree.EndSequence();
            yield return null;
        }


        
       









    }
}
