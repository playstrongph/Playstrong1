using System.Collections;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "CriticalAttackActionAsset", menuName = "SO's/SkillActions/CriticalAttackActionAsset")]
    
    public class CriticalAttackActionAsset : SkillActionAsset
    {
        
        //TOOD this will be changed to a float list of finalAttackModifiers        
        [SerializeField]
        //private int _finalAttackModifier = 1;
        private int _finalAttackValue;



        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
          
            AttackHero();

            LogicTree.EndSequence();
            yield return null;

        }

        private void AttackHero()
        {
            ComputeFinalDamage();
            
            //TODO: Pre-Attack Event Here
            ThisHero.HeroLogic.HeroEvents.PreAttack(ThisHero,TargetHero);
            //if criticalFactor > 1, Pre Critical Strike Event
            
            TargetHero.HeroLogic.HeroEvents.BeforeAttack(ThisHero, TargetHero);
            
            
            VisualTree.AddCurrent(AttackHeroVisual());
            LogicTree.AddCurrent(TargetHero.HeroLogic.TakeDamage.DamageHero(_finalAttackValue));
            
            //TODO: Post-Attack Event Here
            //if criticalFactor > 1, Post Critical Strike Event
            ThisHero.HeroLogic.HeroEvents.PostAttack(ThisHero,TargetHero);
            
            TargetHero.HeroLogic.HeroEvents.AfterAttack(ThisHero, TargetHero);
        }

        private void ComputeFinalDamage()
        {
            var finalAttackModifiers = ThisHero.HeroLogic.BasicAttack.UniqueAttackModifiers;
            var finalCriticalFactor = ThisHero.HeroLogic.BasicAttack.GetCriticalFactor();

            foreach (var finalAttackModifier in finalAttackModifiers)
            {
                _finalAttackValue = Mathf.FloorToInt(finalCriticalFactor * finalAttackModifier * ThisHero.HeroLogic.HeroAttributes.Attack);
            }
        }
        

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
