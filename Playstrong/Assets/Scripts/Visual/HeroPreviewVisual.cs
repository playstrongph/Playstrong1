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
        [RequireInterface(typeof(IHeroObjectReferences))]
        private Object _heroObjectReferences;
        public IHeroObjectReferences HeroObjectReferences => _heroObjectReferences as IHeroObjectReferences; 
        
        [SerializeField]
        private Canvas _previewCanvas;
        public Canvas PreviewCanvas => _previewCanvas;

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

        private ILoadHeroPreviewVisuals _loadHeroPreviewVisuals;
        public ILoadHeroPreviewVisuals LoadHeroPreviewVisuals => _loadHeroPreviewVisuals;

        private Transform _previewTransform;
        public Transform PreviewTransform => _previewTransform;

        private void Awake()
        {
            _loadHeroPreviewVisuals = GetComponent<ILoadHeroPreviewVisuals>();
            _previewTransform = this.transform;
        }
    }
}
