using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Interfaces;
using References;
using ScriptableObjects.AnimationSOscripts;

namespace Visual.Animation
{
    
    [CreateAssetMenu(fileName = "DieAnimation", menuName = "SO's/Animations/DieAnimation")]
    
    public class HeroDiesAnimation : GameAnimations
    {
        //Can be placed in a baseclass
        [SerializeField]
        private float _longAnimationDuration = 2f;
        [SerializeField]
        private float _shortAnimationDuration = 0.5f;

        [SerializeField] private List<GameObject> animationEffects = new List<GameObject>();
        private List<GameObject> AnimationEffects => animationEffects;
        //Can be placed in a baseclass end
        
        
        //Local variables
        private float _doShakeStrength = 10f;
        private int _doShakeVibrato = 10;
        private float _doShakeRandomness = 5f;
        private bool _doShakeSnapping = false;

        private GameObject _dieAnimEffect;

        public override IEnumerator StartAnimation(IHero hero)
        {
            var visualTree = hero.CoroutineTreesAsset.MainVisualTree;
            
            DieAnimation(hero);

            visualTree.EndSequence();
            yield return null;
        }

        private void DieAnimation(IHero hero)
        {
            float skullAnimDuration = _longAnimationDuration;
            float doShakeAnimDuration = _shortAnimationDuration;

            var s = DOTween.Sequence();

            s.Append( hero.HeroTransform.DOShakeRotation(doShakeAnimDuration, _doShakeStrength, _doShakeVibrato, _doShakeRandomness, _doShakeSnapping) );

            s.AppendCallback(() =>
            {
                _dieAnimEffect = Instantiate(AnimationEffects[0], hero.HeroTransform);
            });
            
            s.AppendInterval(skullAnimDuration);

            s.AppendCallback(() =>
            {
                Destroy(_dieAnimEffect);
                hero.HeroVisual.HeroCanvas.enabled = false;
            });

        }

    }
}
