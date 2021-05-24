using System;
using System.Collections;
using DG.Tweening;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class DamageEffect : MonoBehaviour, IDamageEffect
    {
        [SerializeField] private Image _damageEffectImage;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private float _doScaleDuration = 0.2f;
        [SerializeField] private float _localScaleMultiplier = 1.5f;
        [SerializeField] private int _doScaleLoopCount = 4;
        [SerializeField] private float _fadeInterval = 0.2f;
        [SerializeField] private float _fadeAlpha = 0.02f;

        private ICoroutineTree _visualTree;
        private IHero _hero;

        private void Awake()
        {
            _hero = GetComponentInParent<IHero>();
        }

        private void Start()
        {
            _visualTree = _hero.CoroutineTreesAsset.MainVisualTree;
        }

        public void ShowDamage(int damageText)
        {
            StartCoroutine(ShowDamageEffect(damageText));
        }

        public IEnumerator ShowDamageEffect(int damageText)
        {
            _canvas.transform.gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;

            _damageText.text = "-" + damageText.ToString();

            transform.DOScale(transform.localScale * _localScaleMultiplier, _doScaleDuration)
                .SetLoops(_doScaleLoopCount, LoopType.Yoyo).SetEase(Ease.InOutQuad);

            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _fadeAlpha;
                yield return new WaitForSeconds(_fadeInterval);
            }

            _canvas.transform.gameObject.SetActive(false);

            yield return null;
            
        }



    }
}
