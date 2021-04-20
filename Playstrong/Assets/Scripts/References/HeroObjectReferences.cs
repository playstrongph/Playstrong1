using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = System.Object;

namespace References
{
    public class HeroObjectReferences : MonoBehaviour
    {
        // public HeroVisualReferences heroVisualReferences;
        // public BuffsVisual buffsVisual;
        // public HeroPreviewVisual heroPreviewVisual;

        [SerializeField] [RequireInterface(typeof(IHeroVisualReferences))]
        private Object _heroVisualReferences;
        public IHeroVisualReferences HeroVisualReferences => _heroVisualReferences as IHeroVisualReferences;

        [SerializeField] [RequireInterface(typeof(IBuffsVisual))]
        private Object _buffsVisual;
        public IBuffsVisual BuffsVisual => _buffsVisual as IBuffsVisual;

        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;
        
        





    }
}
