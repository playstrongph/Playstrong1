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

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.AddCurrent(PreCriticalStrikeEvents());

            LogicTree.AddCurrent(AttackHero());
            
            LogicTree.AddCurrent(PostCriticalStrikeEvents());
            

            LogicTree.EndSequence();
            yield return null;

        }

        private IEnumerator PreCriticalStrikeEvents()
        {
            ThisHero.HeroLogic.HeroEvents.BeforeCriticalStrike(ThisHero, TargetHero);
            TargetHero.HeroLogic.HeroEvents.PreCriticalStrike(ThisHero, TargetHero);
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostCriticalStrikeEvents()
        {
            ThisHero.HeroLogic.HeroEvents.AfterCriticalStrike(ThisHero, TargetHero);
            TargetHero.HeroLogic.HeroEvents.PostCriticalStrike(ThisHero, TargetHero);
            
            LogicTree.EndSequence();
            yield return null;
        }
        private IEnumerator AttackHero()
        {
            VisualTree.AddCurrent(AttackHeroVisual());
            
            var dealDamage = TargetHero.HeroLogic.DealDamage;
            var attackPower = ThisHero.HeroLogic.HeroAttributes.Attack;
            
            var criticalFactor = ThisHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier/100;

            LogicTree.AddCurrent(dealDamage.DealDamageHero(ThisHero, TargetHero,attackPower, criticalFactor));
            
            LogicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Critical Attack Animation
        /// </summary>
        /// <returns></returns>
        private IEnumerator AttackHeroVisual()
        {
            var doMoveDuration = 0.7f;
            var doMoveLoops = 2;
            var doPunchDuration = 1f;
            var tweenVibrato = 5;
            var tweenElasticity = 0.5f;
            var tweenSnapping = false;
            var s = DOTween.Sequence();

            s.AppendCallback(() => ThisHero.HeroTransform.DOMove(TargetHero.HeroTransform.position, doMoveDuration)
                    .SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    
                    TargetHero.HeroTransform.DOPunchPosition(TargetHero.HeroTransform.position/7 - ThisHero.HeroTransform.position/7, 
                        doPunchDuration, tweenVibrato, tweenElasticity, tweenSnapping)
                );

            s.AppendInterval(doMoveDuration)

                .OnComplete(() =>
                {
                    VisualTree.EndSequence();
                });
            
            
            
            yield return null;
        }
        
       









    }
}
