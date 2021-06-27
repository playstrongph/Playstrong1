using System;
using Interfaces;
using References;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class HeroPreviewVisual : MonoBehaviour, IHeroPreviewVisual
    {
        [SerializeField]
        [RequireInterface(typeof(IHero))]
        private Object _hero;
        public IHero Hero => _hero as IHero;

        [SerializeField]
        private Canvas _previewCanvas;
        public Canvas PreviewCanvas => _previewCanvas;
        
        [SerializeField]
        private Canvas _statusEffectCanvas;
        public Canvas StatusEffectCanvas => _statusEffectCanvas;

        [SerializeField] private GameObject _statusCanvasPanel;
        public GameObject StatusCanvasPanel => _statusCanvasPanel;

        [SerializeField] [RequireInterface(typeof(IHeroPreviewGraphic))]
        private Object _heroPreviewGraphic;
        public IHeroPreviewGraphic HeroPreviewGraphic => _heroPreviewGraphic as IHeroPreviewGraphic;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewName))]
        private Object _heroPreviewName;
        public IHeroPreviewName HeroPreviewName => _heroPreviewName as IHeroPreviewName;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewAttack))]
        private Object _heroPreviewAttack;
        public IHeroPreviewAttack HeroPreviewAttack => _heroPreviewAttack as IHeroPreviewAttack;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewHealth))]
        private Object _heroPreviewHealth;
        public IHeroPreviewHealth HeroPreviewHealth => _heroPreviewHealth as IHeroPreviewHealth;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewSpeed))]
        private Object _heroPreviewSpeed;
        public IHeroPreviewSpeed HeroPreviewSpeed => _heroPreviewSpeed as IHeroPreviewSpeed;

        [SerializeField] [RequireInterface(typeof(IHeroPreviewChance))]
        private Object _heroPreviewChance;
        public IHeroPreviewChance HeroPreviewChance => _heroPreviewChance as IHeroPreviewChance;

        [SerializeField]
        [RequireInterface(typeof(ILoadHeroPreviewVisuals))]
        private Object _loadHeroPreviewVisuals;
        public ILoadHeroPreviewVisuals LoadHeroPreviewVisuals => _loadHeroPreviewVisuals as ILoadHeroPreviewVisuals;

        [SerializeField]
        private Transform _previewTransform;
        public Transform PreviewTransform => _previewTransform;

        
    }
}
