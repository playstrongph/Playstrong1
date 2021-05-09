using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class Hero : MonoBehaviour, IHero
    {

        [SerializeField] [RequireInterface(typeof(IHeroLogic))]
        private Object _heroLogic;
        public IHeroLogic HeroLogic => _heroLogic as IHeroLogic;
        
        [SerializeField] [RequireInterface(typeof(IHeroSkills))]
        private Object _skills;

        public IHeroSkills Skills => _skills as IHeroSkills;
        
        [SerializeField] [RequireInterface(typeof(IHeroVisual))]
        private Object _heroVisual;
        public IHeroVisual HeroVisual => _heroVisual as IHeroVisual;
        
        [SerializeField] [RequireInterface(typeof(IBuffsVisual))]
        private Object _buffsVisual;
        public IBuffsVisual BuffsVisual => _buffsVisual as BuffsVisual;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;

        [SerializeField] [RequireInterface(typeof(IHeroPortrait))]
        private Object _heroPortrait;

        public IHeroPortrait HeroPortrait => _heroPortrait as IHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(IPanelHeroPortrait))]
        private Object _panelHeroPortrait;

        public IPanelHeroPortrait PanelHeroPortrait => _panelHeroPortrait as IPanelHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(PanelHeroSkills))]
        private Object _panelHeroSkills;

        public PanelHeroSkills PanelHeroSkills => _panelHeroSkills as PanelHeroSkills;

        [SerializeField] [RequireInterface(typeof(ILivingHeroes))]
        private Object _livingHeroesReference;

        public ILivingHeroes LivingHeroesReference
        {
            get { return _livingHeroesReference as ILivingHeroes; }
            private set
            {
                _livingHeroesReference = value as Object;
            }
        }

        private void Awake()
        {
            _livingHeroesReference = GetComponentInParent<ILivingHeroes>() as Object;
        }
    }
}
