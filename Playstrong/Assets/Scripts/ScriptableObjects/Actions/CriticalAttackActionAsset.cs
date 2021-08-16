using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "CriticalAttackActionAsset", menuName = "SO's/SkillActions/CriticalAttackActionAsset")]
    
    public class CriticalAttackActionAsset : SkillActionAsset
    {
        private float _preAttackValue;
        private int _finalAttackValue;
        private float _criticalMultiplier;
        
        [SerializeField] private float doMoveDuration = 0.7f;
        [SerializeField] private float doPunchDuration = 1f;
        [SerializeField] private float doPunchDivisor = 5f;
        [SerializeField] private int doMoveLoops = 2;
        [SerializeField] private int tweebVibrato = 5;
        [SerializeField] private float tweenElasticity = 0.5f;
        [SerializeField] private bool tweenSnapping = false;
       

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
            logicTree.AddCurrent(dealDamage.DealDamageHero(thisHero, targetHero,attackPower, criticalFactor));
            logicTree.AddCurrent(AttackInterval(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AttackHeroLogic(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
            visualTree.AddCurrent(AttackHeroVisual(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Critical Attack Animation
        /// </summary>
        /// <returns></returns>
        private IEnumerator AttackHeroVisual(IHero thisHero, IHero targetHero)
        {
            Debug.Log("CriticalAttackHeroVisual Start: " +thisHero.HeroName);
            
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            var s = DOTween.Sequence();
            var targetPosition = targetHero.HeroTransform.position;
            var attackerPosition = thisHero.HeroTransform.position;

            
            s.AppendCallback(() => thisHero.HeroTransform.DOMove(targetHero.HeroTransform.position, doMoveDuration).SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    targetHero.HeroTransform.DOPunchPosition((targetPosition - attackerPosition)/doPunchDivisor,doPunchDuration, tweebVibrato, tweenElasticity, tweenSnapping)
                );
            s.AppendInterval(doMoveDuration)     
                .OnComplete(() =>                  
                {
                    Debug.Log("CriticalAttackHeroVisual End: " +thisHero.HeroName);
                    visualTree.EndSequence();
                });
            yield return null;
        }
        
        private IEnumerator AttackInterval(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
            visualTree.AddCurrent(ReturnToPositionInterval(thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator ReturnToPositionInterval(IHero thisHero, IHero targetHero)
        {
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            
            Debug.Log("Attack Interval Start: " +thisHero.HeroName);
            var s1 = DOTween.Sequence();
            s1.AppendInterval(doPunchDuration)
                
                .OnComplete(() =>                  
                {
                    Debug.Log("Attack Interval End: " +thisHero.HeroName);
                    visualTree.EndSequence();
                });
            
            
            yield return null;
        }
        
       









    }
}
