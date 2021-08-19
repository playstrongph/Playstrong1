using System.Collections;
using DG.Tweening;
using Interfaces;
using UnityEngine;


namespace ScriptableObjects.AnimationSOscripts
{
    [CreateAssetMenu(fileName = "BasicAttackAnimation", menuName = "SO's/GameAnimations/BasicAttackAnimation")]
    public class BasicAttackAnimation : GameAnimations
    {
        [SerializeField] private float doMoveDuration = 0.7f;
        [SerializeField] private float doPunchDuration = 1f;
        [SerializeField] private float doPunchDivisor = 5f;
        [SerializeField] private int doMoveLoops = 2;
        [SerializeField] private int tweenVibrato = 5;
        [SerializeField] private float tweenElasticity = 0.5f;
        [SerializeField] private bool tweenSnapping = false;
        
        public override IEnumerator StartAnimation(IHero thisHero, IHero targetHero)
        {
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            visualTree.AddCurrent(AttackHeroVisual(thisHero,targetHero));
            
            visualTree.EndSequence();
            yield return null;
        }

        private IEnumerator AttackHeroVisual(IHero thisHero, IHero targetHero)
        {
            Debug.Log("AttackHeroVisual Start: " +thisHero.HeroName);
            
            var visualTree = thisHero.CoroutineTreesAsset.MainVisualTree;
            var s = DOTween.Sequence();
            var targetPosition = targetHero.HeroTransform.position;
            var attackerPosition = thisHero.HeroTransform.position;

            
            s.AppendCallback(() => thisHero.HeroTransform.DOMove(targetHero.HeroTransform.position, doMoveDuration).SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    targetHero.HeroTransform.DOPunchPosition((targetPosition - attackerPosition)/doPunchDivisor,doPunchDuration, tweenVibrato, tweenElasticity, tweenSnapping)
                );
            s.AppendInterval(doMoveDuration)     
                .OnComplete(() =>                  
                {
                    Debug.Log("AttackHeroVisual End: " +thisHero.HeroName);
                    visualTree.EndSequence();
                });
            yield return null;
        }
        
        
        
    }
}
