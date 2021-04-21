using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class HeroObjectReferences : MonoBehaviour, IHeroObjectReferences
    {
        
        [SerializeField] [RequireInterface(typeof(IHeroVisualReferences))]
        private Object _heroVisualReferences;
        public IHeroVisualReferences HeroVisualReferences => _heroVisualReferences as IHeroVisualReferences;
        
        [SerializeField] [RequireInterface(typeof(IBuffsVisual))]
        private Object _buffsVisual;
        public IBuffsVisual BuffsVisual => _buffsVisual as BuffsVisual;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;
        
        //Temp Script
        [SerializeField] [RequireInterface(typeof(IHeroAsset))]
        private Object _heroAsset;

        public IHeroAsset HeroAsset => _heroAsset as IHeroAsset;
        
        
        private void Awake()
        {
            var loadHeroVisuals = GetComponentInChildren<ILoadHeroVisuals>();
            var loadHeroPreviewVisuals = GetComponentInChildren<ILoadHeroPreviewVisuals>();
            
            loadHeroVisuals.LoadHeroVisualsFromHeroAsset(HeroAsset);       
            loadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset(HeroAsset);

        }
    }
}
