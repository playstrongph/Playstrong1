using System.Collections;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "AttackActionAsset", menuName = "SO's/SkillActions/AttackActionAsset")]
    
    public class AttackActionAsset : SkillActionAsset
    {
        
       
        private int _finalAttackValue;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            //Originals START
            //LogicTree.AddCurrent(ComputeFinalDamage());
            //LogicTree.AddCurrent(AttackHero());
            //Originals END
            
            Debug.Log("Normal Attack");
            
            LogicTree.AddCurrent(AttackHeroTest());
            
            //TEST START
            
            //TEST END
            

            LogicTree.EndSequence();
            yield return null;

        }

        private IEnumerator AttackHero()
        {
            VisualTree.AddCurrent(AttackHeroVisual());

            var dealDamage = TargetHero.HeroLogic.DealDamage;
            LogicTree.AddCurrent(dealDamage.DealDamageHero(ThisHero, TargetHero,_finalAttackValue));
            
            LogicTree.EndSequence();
            yield return null;
        }

        private IEnumerator ComputeFinalDamage()
        {
            var finalAttackModifiers = ThisHero.HeroLogic.BasicAttack.UniqueAttackModifiers;
            

            foreach (var finalAttackModifier in finalAttackModifiers)
            {
                _finalAttackValue = Mathf.FloorToInt(finalAttackModifier * ThisHero.HeroLogic.HeroAttributes.Attack);
            }
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        //TEST
        private IEnumerator AttackHeroTest()
        {
            VisualTree.AddCurrent(AttackHeroVisual());
            
            var dealDamage = TargetHero.HeroLogic.DealDamage;
            var attackPower = ThisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;
            
            LogicTree.AddCurrent(dealDamage.DealDamageHeroTest(ThisHero, TargetHero,attackPower, criticalFactor));
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        //TEST END
        
        
        
        
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
