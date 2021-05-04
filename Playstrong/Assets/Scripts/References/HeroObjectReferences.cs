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

        [SerializeField] [RequireInterface(typeof(IHeroLogic))]
        private Object _heroLogicReferences;
        public IHeroLogic HeroLogic => _heroLogicReferences as IHeroLogic;
        
        [SerializeField] [RequireInterface(typeof(IHeroSkillsReference))]
        private Object _skillsReference;

        public IHeroSkillsReference SkillsReference => _skillsReference as IHeroSkillsReference;
        
        [SerializeField] [RequireInterface(typeof(IHeroVisualReferences))]
        private Object _heroVisualReferences;
        public IHeroVisualReferences HeroVisualReferences => _heroVisualReferences as IHeroVisualReferences;
        
        [SerializeField] [RequireInterface(typeof(IBuffsVisual))]
        private Object _buffsVisual;
        public IBuffsVisual BuffsVisual => _buffsVisual as BuffsVisual;
        
        [SerializeField] [RequireInterface(typeof(IHeroPreviewVisual))]
        private Object _heroPreviewVisual;
        public IHeroPreviewVisual HeroPreviewVisual => _heroPreviewVisual as IHeroPreviewVisual;

        [SerializeField] [RequireInterface(typeof(IHeroPortrait))]
        private Object _heroPortrait;

        public IHeroPortrait HeroPortrait => _heroPortrait as IHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(IHeroPortrait))]
        private Object _panelHeroPortrait;

        public IHeroPortrait PanelHeroPortrait => _panelHeroPortrait as IHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(IHeroSkillsReference))]
        private Object _panelSkillsReference;

        public IHeroSkillsReference PanelSkillsReference => _panelSkillsReference as IHeroSkillsReference;




    }
}
