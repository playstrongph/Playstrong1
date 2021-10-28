using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace Visual
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        
        private IHeroVisual _heroVisual;
        
        private IHeroAttributes _heroAttributes;
        private IOtherAttributes _otherAttributes;
        
        private int _initialEnergy = 0;

        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
            _heroAttributes = _heroVisual.Hero.HeroLogic.HeroAttributes;
            _otherAttributes = _heroVisual.Hero.HeroLogic.OtherAttributes;

        }

        private void Start()
        {
           
        }


        public void LoadHeroVisualsFromHeroAsset(IHeroAsset heroAsset)
        {
            
            _heroVisual.HeroGraphic.HeroImage.sprite = heroAsset.HeroSprite;
            
            _heroVisual.AttackVisual.SetAttackText(_heroAttributes.Attack.ToString());
            _heroVisual.ArmorVisual.SetArmorText(_heroAttributes.Armor);
            _heroVisual.HealthVisual.SetHealthText(_heroAttributes.Health.ToString());
            _heroVisual.EnergyVisual.SetEnergyTextAndBarFill(_initialEnergy);
            
            //Test
            _heroVisual.FightingSpiritVisual.SetFightingSpiritText(_otherAttributes.FightingSpirit);
            

        }



    }
}
