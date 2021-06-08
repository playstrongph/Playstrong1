﻿using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroStatusEffects : MonoBehaviour, IHeroStatusEffects
    {

        [SerializeField] private GameObject _heroStatusEffectPrefab;

        public GameObject HeroStatusEffectPrefab => _heroStatusEffectPrefab;
        


        [SerializeField]
        private Canvas _statusEffectsCanvas;
        public Canvas StatusEffectsCanvas => _statusEffectsCanvas;

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectsPanel))]
        private Object _statusEffectsPanel;
        public IStatusEffectsPanel StatusEffectsPanel => _statusEffectsPanel as IStatusEffectsPanel;

        private IStatusEffectsVisual _statusEffectsVisual;
        public IStatusEffectsVisual StatusEffectsVisual => _statusEffectsVisual;

        private IHeroBuffEffects _heroBuffEffects;
        public IHeroBuffEffects HeroBuffEffects => _heroBuffEffects as IHeroBuffEffects;
        
        private IHeroDebuffEffects _heroDebuffEffects;
        public IHeroDebuffEffects HeroDebuffEffects => _heroDebuffEffects as IHeroDebuffEffects;


        private void Awake()
        {
            _statusEffectsVisual = GetComponent<IStatusEffectsVisual>();
            _heroBuffEffects = GetComponent<IHeroBuffEffects>();
            _heroDebuffEffects = GetComponent<IHeroDebuffEffects>();

          

        }
    }
}
