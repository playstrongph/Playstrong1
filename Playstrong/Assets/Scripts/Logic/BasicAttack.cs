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

        private IHeroLogic _thisHeroLogic;
        
        private int _attackModifier = 1;
        private int _finalAttackValue;
        
        private IHero _thisHero;
       
        
        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
            _thisHero = _thisHeroLogic.Hero;
       
        }

        private void Start()
        {
            _logicTree = _thisHero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHero.CoroutineTreesAsset.MainVisualTree;
        }

        public IEnumerator TargetHero(IHero targetHero)
        {
            _visualTree.AddCurrent(VisualBasicAttackHero(targetHero));
            
            ModifyAttack(_attackModifier);
            
            _logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.DamageHero(_finalAttackValue));
            
            yield return null;
            _logicTree.EndSequence();
        }


        /*public IEnumerator BasicAttackHero(IHero targetHero)
        {
            _visualTree.AddCurrent(VisualBasicAttackHero(targetHero));            
            ModifyAttack(_attackModifier);            
            _logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.DamageHero(_finalAttackValue));            
            yield return null;
            _logicTree.EndSequence();
        }*/

        private IEnumerator VisualBasicAttackHero(IHero targetHero)
        {
            var doMoveDuration = 0.7f;
            var doMoveLoops = 2;
            var doPunchDuration = 1f;
            var tweenVibrato = 5;
            var tweenElasticity = 0.5f;
            var tweenSnapping = false;
            var s = DOTween.Sequence();

            s.AppendCallback(() => _thisHero.HeroTransform.DOMove(targetHero.HeroTransform.position, doMoveDuration)
                .SetLoops(doMoveLoops, LoopType.Yoyo).SetEase(Ease.InBack))
                .OnStepComplete(() =>
                    
                    targetHero.HeroTransform.DOPunchPosition(targetHero.HeroTransform.position/7 - _thisHero.HeroTransform.position/7, 
                        doPunchDuration, tweenVibrato, tweenElasticity, tweenSnapping)
                );

            s.AppendInterval(doMoveDuration)

                .OnComplete(() =>
                {
                    _visualTree.EndSequence();            
                        
                });
            
            yield return null;
        }

        public void ModifyAttack(int attackModifier)
        {
            _attackModifier = attackModifier;
            _finalAttackValue = _attackModifier * _thisHeroLogic.HeroAttributes.Attack;
        }








    }
}
