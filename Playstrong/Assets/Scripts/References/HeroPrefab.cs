﻿using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class HeroPrefab : MonoBehaviour, IHeroPrefab
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
        
        [SerializeField] [RequireInterface(typeof(IHeroPortrait))]
        private Object _panelHeroPortrait;

        public IHeroPortrait PanelHeroPortrait => _panelHeroPortrait as IHeroPortrait;
        
        [SerializeField] [RequireInterface(typeof(IHeroSkills))]
        private Object _panelHeroSkills;

        public IHeroSkills PanelHeroSkills => _panelHeroSkills as IHeroSkills;




    }
}
