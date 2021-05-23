using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace Logic
{
    public class BasicAttack : MonoBehaviour, IBasicAttack
    {
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IHeroLogic _heroLogic;
        private int _heroAttackPower;
        
        private int _targetArmor;
        private int _targetHealth;
        private IHero _thisHero;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
            _heroAttackPower = _heroLogic.HeroAttributes.Attack;
            _thisHero = _heroLogic.Hero;
        }

        private void Start()
        {
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _heroLogic.Hero.CoroutineTreesAsset.MainVisualTree;
        }

        public IEnumerator BasicAttackHero(IHero targetHero)
        {
            _visualTree.AddCurrent(VisualBasicAttackHero(targetHero));
            //TODO: DealDamage
            
            yield return null;
            _logicTree.EndSequence();
        }


        private IEnumerator VisualBasicAttackHero(IHero targetHero)
        {
            var doMoveDuration = 0.7f;
            var doMoveLoops = 2;
            var doPunchDuration = 1f;
            var tweenVibrato = 5;
            var tweenElasticity = 0.5f;
            var tweenSnipping = false;
            var s = DOTween.Sequence();

            s.AppendCallback(() => _thisHero.HeroTransform.DOMove(targetHero.HeroTransform.position, doMoveDuration)
                .SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    
                    targetHero.HeroTransform.DOPunchPosition(targetHero.HeroTransform.position/7 - _thisHero.HeroTransform.position/7, 
                        doPunchDuration, tweenVibrato, tweenElasticity, tweenSnipping)
                );

            s.AppendInterval(doMoveDuration);

            yield return null;
            _visualTree.EndSequence();
        }








    }
}
