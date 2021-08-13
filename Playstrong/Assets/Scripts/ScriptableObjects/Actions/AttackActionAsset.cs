using System.Collections;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;
using UnityEngine.Accessibility;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "AttackActionAsset", menuName = "SO's/SkillActions/AttackActionAsset")]
    
    public class AttackActionAsset : SkillActionAsset {
        
       
        private int _finalAttackValue;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            LogicTree.AddCurrent(AttackHero());

            LogicTree.EndSequence();
            yield return null;

        }
        

        private IEnumerator AttackHero()
        {
            //VisualTree.AddCurrent(AttackHeroVisual());
            LogicTree.AddCurrent(AttackHeroLogic());
            
            var dealDamage = TargetHero.HeroLogic.DealDamage;
            var attackPower = ThisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;
            
            LogicTree.AddCurrent(dealDamage.DealDamageHero(ThisHero, TargetHero,attackPower, criticalFactor));
            
            //Insert Delay Here
            //LogicTree.AddCurrent(AttackInterval());
            
            LogicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Attack Animation
        /// TODO: Separate this
        /// </summary>
        private IEnumerator AttackHeroVisual()
        {
            var doMoveDuration = 0.7f;
            var doMoveLoops = 2;
            var doPunchDuration = 1f;
            var tweenVibrato = 5;
            var tweenElasticity = 0.5f;
            var tweenSnapping = false;
            var s = DOTween.Sequence();
            
            var s1 = DOTween.Sequence();


            s.AppendCallback(() => ThisHero.HeroTransform.DOMove(TargetHero.HeroTransform.position, doMoveDuration)
                .SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack));
                
                /*
                .OnStepComplete(() =>
                    
                    TargetHero.HeroTransform.DOPunchPosition(TargetHero.HeroTransform.position/7 - ThisHero.HeroTransform.position/7, 
                        doPunchDuration, tweenVibrato, tweenElasticity, tweenSnapping)
                );

            s.AppendInterval(doMoveDuration);       //this is the interval for the DO PunchPosition
            */
            
            
            s1.AppendInterval(2f*doMoveDuration)


                .OnComplete(() =>                  //No Interval for OnComplete, that's why it's called at the same time as DoPunch
                {
                    VisualTree.EndSequence();
                });

            
            
            yield return null;
        }
        
        
        //TEST

        private IEnumerator AttackHeroLogic()
        {
            VisualTree.AddCurrent(AttackHeroVisual());
            
            LogicTree.EndSequence();
            yield return null;
        }

        private IEnumerator AttackInterval()
        {
            VisualTree.AddCurrent(ReturnToPositionInterval());
            
            LogicTree.EndSequence();
            yield return null;
        }


        private IEnumerator ReturnToPositionInterval()
        {
            var s = DOTween.Sequence();
            
            var doMoveDuration = 0.7f;
            s.AppendCallback(() =>
                
               Debug.Log("Interval Delay")
                
            );
            
            s.AppendInterval(2f*doMoveDuration)
                
                .OnComplete(() =>                  
                {
                    VisualTree.EndSequence();
                });
            
            
            yield return null;
        }








    }
}
