using System;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        
        private IHeroVisualReferences _heroVisualReferences;
        private IHeroAttributes _heroAttributes;
        
        private int _initialEnergy = 0;

        private void Awake()
        {
            _heroVisualReferences = GetComponent<IHeroVisualReferences>();
            _heroAttributes = _heroVisualReferences.HeroObjectReferences.HeroLogic.HeroAttributes;

        }

        private void Start()
        {
           
        }


        public void LoadHeroVisualsFromHeroAsset(IHeroAsset heroAsset)
        {
            
            _heroVisualReferences.HeroGraphic.HeroImage.sprite = heroAsset.HeroSprite;
            
            _heroVisualReferences.AttackVisual.SetAttackText(_heroAttributes.Attack.ToString());
            _heroVisualReferences.ArmorVisual.SetArmorText(_heroAttributes.Armor.ToString());
            _heroVisualReferences.HealthVisual.SetHealthText(_heroAttributes.Health.ToString());
            _heroVisualReferences.EnergyVisual.SetEnergyTextAndBarFill(_initialEnergy);
            

        }



    }
}
