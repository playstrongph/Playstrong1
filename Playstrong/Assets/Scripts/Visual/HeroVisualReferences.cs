using System.Collections.Generic;
using Assets.Scripts.References;
using Assets.Scripts.Utilities;
using Assets.Scripts.Visual.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class HeroVisualReferences : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;   
        
        [SerializeField]
        private Canvas heroCanvas;
        public Canvas HeroCanvas => heroCanvas;

        
        [SerializeField]
        [RequireInterface(typeof(ITauntFrameAndGlow))]
        private Object _tauntFrameAndGlow;
        public ITauntFrameAndGlow TauntFrameAndGlow => _tauntFrameAndGlow as ITauntFrameAndGlow;

        [SerializeField] 
        private INormalFrameAndGlow _normalFrameAndGlow;
        //public INormalFrameAndGlow NormalFrameAndGlow => _normalFrameAndGlow as INormalFrameAndGlow;

        [SerializeField]
        private ISetHeroGraphic _heroGraphic;
        //public ISetHeroGraphic HeroGraphic => _heroGraphic as ISetHeroGraphic;


        private void Awake()
        {
            _normalFrameAndGlow = GetComponent<INormalFrameAndGlow>();
            _heroGraphic = GetComponent<ISetHeroGraphic>();
        }

    }
}
