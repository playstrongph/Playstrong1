using Interfaces;
using UnityEngine;
using Utilities;
using Visual;


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

        /// <summary>
        /// For Testing Purposes Only
        /// </summary>
        /// <returns></returns>
        [SerializeField] [RequireInterface(typeof(IHeroAsset))]
        private Object _heroAsset;
        public IHeroAsset HeroAsset => _heroAsset as IHeroAsset;


    }
}
