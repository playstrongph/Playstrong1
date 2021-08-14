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

            LogicTree.AddCurrent(AttackHero());

            LogicTree.EndSequence();
            yield return null;

        }
        

        private IEnumerator AttackHero()
        {
            
            var dealDamage = TargetHero.HeroLogic.DealDamage;
            var attackPower = ThisHero.HeroLogic.HeroAttributes.Attack;
            var criticalFactor = 0;

            
            LogicTree.AddCurrent(AttackHeroLogic());
            
            LogicTree.AddCurrent(dealDamage.DealDamageHero(ThisHero, TargetHero,attackPower, criticalFactor));
            
            LogicTree.AddCurrent(AttackInterval());

            LogicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        private IEnumerator AttackHeroLogic()
        {
            VisualTree.AddCurrent(AttackHeroVisual());
            
            LogicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Attack Animation
        /// TODO: Separate this
        /// </summary>
        private IEnumerator AttackHeroVisual()
        {
            
            Debug.Log("AttackHeroVisual Start: " +ThisHero.HeroName);
            
            var s = DOTween.Sequence();
            var s1 = DOTween.Sequence();

            var targetPosition = TargetHero.HeroTransform.position;
            var attackerPosition = ThisHero.HeroTransform.position;

            
            s.AppendCallback(() => ThisHero.HeroTransform.DOMove(TargetHero.HeroTransform.position, _doMoveDuration).SetLoops(_doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    TargetHero.HeroTransform.DOPunchPosition((targetPosition - attackerPosition)/_doPunchDivisor,_doPunchDuration, _tweebVibrato, _tweenElasticity, _tweenSnapping)
                );
            s.AppendInterval(_doMoveDuration)     
            .OnComplete(() =>                  
                {
                    Debug.Log("AttackHeroVisual End: " +ThisHero.HeroName);
                    VisualTree.EndSequence();
                });
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
            Debug.Log("Attack Interval Start: " +ThisHero.HeroName);
            var s3 = DOTween.Sequence();
            s3.AppendInterval(_doMoveDuration)
                
                .OnComplete(() =>                  
                {
                    Debug.Log("Attack Interval End: " +ThisHero.HeroName);
                    VisualTree.EndSequence();
                });
            
            
            yield return null;
        }








    }
}
