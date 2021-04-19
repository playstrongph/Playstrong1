using System.Collections.Generic;
using System.Runtime.Remoting;
using Assets.Scripts.References;
using Assets.Scripts.Utilities;
using Assets.Scripts.Visual.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class HeroPreviewVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;
        
        [SerializeField]
        private Canvas previewCanvas;

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
        public IHeroPreviewChance HeroPreviewChance => _heroPreviewHealth as IHeroPreviewChance;



    }
}
