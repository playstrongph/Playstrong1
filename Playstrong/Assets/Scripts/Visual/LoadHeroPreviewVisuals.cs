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
            _heroAttributes = _heroPreviewVisualReferences.Hero.HeroLogic.HeroAttributes;
        }

        private void Start()
        {
           
        }

        public void LoadHeroPreviewVisualsFromAsset(IHeroAsset heroAsset)
        {
       
            _heroPreviewVisualReferences.HeroPreviewGraphic.SetHeroPreviewGraphic(heroAsset.HeroSprite);
            _heroPreviewVisualReferences.HeroPreviewName.SetHeroPreviewName(heroAsset.Name);
            
            
            UpdateHeroPreviewAttributes();
            
        
        }

        public void UpdateHeroPreviewAttributes()
        {
            //_heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttack(_heroAttributes.Attack.ToString());
            SetHeroPreviewAttackVisual();
            
            _heroPreviewVisualReferences.HeroPreviewHealth.SetHeroPreviewHealth(_heroAttributes.Health.ToString());
            
            //_heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeedText(_heroAttributes.Speed.ToString());
            SetHeroPreviewSpeedVisual();
            
            _heroPreviewVisualReferences.HeroPreviewChance.SetHeroPreviewChance(_heroAttributes.Chance.ToString());
            
        }

        private void SetHeroPreviewAttackVisual()
        {
            var baseAttack = _heroAttributes.BaseAttack;
            var attack = _heroAttributes.Attack;
            var textColor = GetTextColor(baseAttack, attack);
            
            _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackText(_heroAttributes.Attack.ToString());
            _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackColor(textColor);
        }

        private void SetHeroPreviewSpeedVisual()
        {
            var baseSpeed = _heroAttributes.BaseSpeed;
            var speed = _heroAttributes.Speed;
            var textColor = GetTextColor(baseSpeed, speed); 
            
            _heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeedText(_heroAttributes.Speed.ToString());
            _heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeedColor(textColor);
            
        }


        private Color GetTextColor(int baseValue, int value)
        {
            if(value>baseValue)
               return Color.green;
            else if (value == baseValue)
                return Color.white;
            else if(value < baseValue)
               return Color.red;
            else
                return Color.white;
            
        }


    }
}
