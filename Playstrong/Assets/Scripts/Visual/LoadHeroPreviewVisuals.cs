using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadHeroPreviewVisuals : MonoBehaviour, ILoadHeroPreviewVisuals
    {
   
       
        private IHeroPreviewVisual _heroPreviewVisualReferences;
        private IHeroAttributes _heroAttributes;

        private void Awake()
        {
            _heroPreviewVisualReferences = GetComponent<IHeroPreviewVisual>();
            _heroAttributes = _heroPreviewVisualReferences.HeroObjectReferences.HeroLogicReferences.HeroAttributes;
        }

        private void Start()
        {
           
        }

        public void LoadHeroPreviewVisualsFromAsset(IHeroAsset heroAsset, List<Transform> previewLocations)
        {
       
            _heroPreviewVisualReferences.HeroPreviewGraphic.SetHeroPreviewGraphic(heroAsset.HeroSprite);
            
            _heroPreviewVisualReferences.HeroPreviewName.SetHeroPreviewName(heroAsset.Name);
            _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttack(_heroAttributes.Attack.ToString());
            _heroPreviewVisualReferences.HeroPreviewHealth.SetHeroPreviewHealth(_heroAttributes.Health.ToString());
            _heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeed(_heroAttributes.Speed.ToString());
            _heroPreviewVisualReferences.HeroPreviewChance.SetHeroPreviewChance(_heroAttributes.Chance.ToString());
            
        
        }

        
    }
}
