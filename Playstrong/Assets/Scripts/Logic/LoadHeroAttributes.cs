using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class LoadHeroAttributes : MonoBehaviour, ILoadHeroAttributes
    {
        private IHeroAttributes _heroAttributes;
        private int _initalHeroEnergy = 0;

        private void Awake()
        {
            _heroAttributes = GetComponent<IHeroAttributes>();
        }

        public void LoadHeroAttributesFromHeroAsset(IHeroAsset heroAsset)
        {
            _heroAttributes.Attack = heroAsset.Attack;
            _heroAttributes.BaseAttack = heroAsset.Attack;
            
            _heroAttributes.Health = heroAsset.Health;
            _heroAttributes.BaseHealth = heroAsset.Health;
            
            _heroAttributes.Armor = heroAsset.Armor;
            _heroAttributes.BaseArmor = heroAsset.Armor;
            
            _heroAttributes.Speed = heroAsset.Speed;
            _heroAttributes.BaseSpeed = heroAsset.Speed;
            
            _heroAttributes.Chance = heroAsset.Chance;
            _heroAttributes.BaseChance = heroAsset.Chance;
            
            _heroAttributes.Energy = _initalHeroEnergy;

        }
        
        

    }
}
