using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class HeroObjectReferences : MonoBehaviour, IHeroObjectReferences
    {

        [SerializeField] [RequireInterface(typeof(IHeroLogicReferences))]
        private Object _heroLogicReferences;
        public IHeroLogicReferences HeroLogicReferences => _heroLogicReferences as IHeroLogicReferences;
        
        [SerializeField] [RequireInterface(typeof(IHeroVisualReferences))]
        private Object _heroVisualReferences;
        public IHeroVisualReferences HeroVisualReferences => _heroVisualReferences as IHeroVisualReferences;
        
        [SerializeField] [RequireInterface(typeof(IBuffsVisual))]
        private Object _buffsVisual;
        public IBuffsVisual BuffsVisual => _buffsVisual as BuffsVisual;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;
        
       
        
        
        
        
    }
}
