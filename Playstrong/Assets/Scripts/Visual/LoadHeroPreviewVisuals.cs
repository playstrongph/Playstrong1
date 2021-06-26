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
            SetAttack();
            
            _heroPreviewVisualReferences.HeroPreviewHealth.SetHeroPreviewHealth(_heroAttributes.Health.ToString());
            
            _heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeed(_heroAttributes.Speed.ToString());
            
            _heroPreviewVisualReferences.HeroPreviewChance.SetHeroPreviewChance(_heroAttributes.Chance.ToString());
            
        }

        private void SetAttack()
        {
            var baseAttack = _heroAttributes.BaseAttack;
            var attack = _heroAttributes.Attack;
            
            _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackText(_heroAttributes.Attack.ToString());
            
            if(attack>baseAttack)
                _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackColor(Color.green);
            if(attack == baseAttack)
                _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackColor(Color.white);
            if(attack < baseAttack)
                _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttackColor(Color.red);

        }


    }
}
