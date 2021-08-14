using System.Collections;
using DG.Tweening;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using UnityEngine;
using UnityEngine.Accessibility;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "AttackActionAsset", menuName = "SO's/SkillActions/AttackActionAsset")]
    
    public class AttackActionAsset : SkillActionAsset
    {

        [SerializeField] private float _doMoveDuration = 1f;
        [SerializeField] private float _doPunchDuration = 0.7f;
        [SerializeField] private float _doPunchDivisor = 5f;
        [SerializeField] private int _doMoveLoops = 2;
        [SerializeField] private int _tweebVibrato = 5;
        [SerializeField] private float _tweenElasticity = 0.5f;
        [SerializeField] private bool _tweenSnapping = false;


        private int _finalAttackValue;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);

            LogicTree.AddCurrent(AttackHero(thisHero,targetHero));

            LogicTree.EndSequence();
            yield return null;

        }
        

        private IEnumerator AttackHero(IHero thisHero, IHero targetHero)
        {
            
            var dealDamage = targetHero.HeroLogic.DealDamage;
            var attackPower = thisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;

            
            LogicTree.AddCurrent(AttackHeroLogic(thisHero,targetHero));
            
            LogicTree.AddCurrent(dealDamage.DealDamageHero(thisHero, targetHero,attackPower, criticalFactor));
            
            LogicTree.AddCurrent(AttackInterval(thisHero,targetHero));

            LogicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        private IEnumerator AttackHeroLogic(IHero thisHero, IHero targetHero)
        {
            VisualTree.AddCurrent(AttackHeroVisual(thisHero,targetHero));
            
            LogicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Attack Animation
        /// TODO: Separate this
        /// </summary>
        private IEnumerator AttackHeroVisual(IHero thisHero, IHero targetHero)
        {
            
            Debug.Log("AttackHeroVisual Start: " +thisHero.HeroName);
            
            var s = DOTween.Sequence();
            var s1 = DOTween.Sequence();

            var targetPosition = targetHero.HeroTransform.position;
            var attackerPosition = thisHero.HeroTransform.position;

            
            s.AppendCallback(() => thisHero.HeroTransform.DOMove(targetHero.HeroTransform.position, _doMoveDuration).SetLoops(_doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    targetHero.HeroTransform.DOPunchPosition((targetPosition - attackerPosition)/_doPunchDivisor,_doPunchDuration, _tweebVibrato, _tweenElasticity, _tweenSnapping)
                );
            s.AppendInterval(_doMoveDuration)     
            .OnComplete(() =>                  
                {
                    Debug.Log("AttackHeroVisual End: " +thisHero.HeroName);
                    VisualTree.EndSequence();
                });
            yield return null;
        }
        
        
        

        private IEnumerator AttackInterval(IHero thisHero, IHero targetHero)
        {
            VisualTree.AddCurrent(ReturnToPositionInterval(thisHero,targetHero));
            
            LogicTree.EndSequence();
            yield return null;
        }


        private IEnumerator ReturnToPositionInterval(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Attack Interval Start: " +thisHero.HeroName);
            var s3 = DOTween.Sequence();
            s3.AppendInterval(_doPunchDuration)
                
                .OnComplete(() =>                  
                {
                    Debug.Log("Attack Interval End: " +thisHero.HeroName);
                    VisualTree.EndSequence();
                });
            
            
            yield return null;
        }








    }
}
