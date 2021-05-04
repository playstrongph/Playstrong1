using System;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        
        private IHeroVisual _heroVisual;
        private IHeroAttributes _heroAttributes;
        
        private int _initialEnergy = 0;

        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
            _heroAttributes = _heroVisual.HeroPrefab.HeroLogic.HeroAttributes;

        }

        private void Start()
        {
           
        }


        public void LoadHeroVisualsFromHeroAsset(IHeroAsset heroAsset)
        {
            
            _heroVisual.HeroGraphic.HeroImage.sprite = heroAsset.HeroSprite;
            
            _heroVisual.AttackVisual.SetAttackText(_heroAttributes.Attack.ToString());
            _heroVisual.ArmorVisual.SetArmorText(_heroAttributes.Armor.ToString());
            _heroVisual.HealthVisual.SetHealthText(_heroAttributes.Health.ToString());
            _heroVisual.EnergyVisual.SetEnergyTextAndBarFill(_initialEnergy);
            

        }



    }
}
