﻿using System.Collections;
using DG.Tweening;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AttackActionAsset", menuName = "SO's/SkillActions/AttackActionAsset")]
    
    public class AttackActionAsset : SkillActionAsset
    {
        
        //TOOD this will be changed to a float list of finalAttackModifiers        
        [SerializeField]
        private int _finalAttackModifier = 1;
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
            VisualTree.AddCurrent(AttackHeroVisual());
            LogicTree.AddCurrent(ComputeFinalDamage());
            LogicTree.AddCurrent(TargetHero.HeroLogic.TakeDamage.DamageHero(_finalAttackValue));
        }

        private IEnumerator ComputeFinalDamage()
        {
            //TODO: change this to foreach implementation
            _finalAttackValue = _finalAttackModifier * ThisHero.HeroLogic.HeroAttributes.Attack;
            
            LogicTree.EndSequence();
            yield return null;
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
