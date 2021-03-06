using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class HeroAttributes : MonoBehaviour, IHeroAttributes
    {

        [SerializeField] private int _attack;

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
    
      
    
        [SerializeField] private int _health;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    
       
    
        [SerializeField] private int _armor;

        public int Armor
        {
            get { return _armor; }
            set
            {
                _armor = value;
            }
        }
    
     
    
        [SerializeField] private int _speed;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    
        
        [SerializeField] private int _chance;

        public int Chance
        {
            get { return _chance; }
            set { _chance = value; }
        }
    
       
    
        [SerializeField] private int _energy;

        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
        
        [Header("Base Values")]
        
        [SerializeField] private int _baseAttack;

        public int BaseAttack
        {
            get { return _baseAttack; }
            set { _baseAttack = value; }
        }
        
        [SerializeField] private int _baseHealth;

        public int BaseHealth
        {
            get { return _baseHealth; }
            set { _baseHealth = value; }
        }
        
        [SerializeField] private int _baseArmor;

        public int BaseArmor
        {
            get { return _baseArmor; }
            set { _baseArmor = value; }
        }
        
        [SerializeField] private int _baseSpeed;

        public int BaseSpeed
        {
            get { return _baseSpeed; }
            set { _baseSpeed = value; }
        }
        
        [SerializeField] private int _baseChance;

        public int BaseChance
        {
            get { return _baseChance; }
            set { _baseChance = value; }
        }


        
        [Header("Original Values")]

        [SerializeField] private int _heroAssetAttack;

        public int HeroAssetAttack
        {
            get => _heroAssetAttack;
            set => _heroAssetAttack = value;
        }
        
        [SerializeField] private int _heroAssetHealth;

        public int HeroAssetHealth
        {
            get => _heroAssetHealth;
            set => _heroAssetHealth = value;
        }
        
        [SerializeField] private int _heroAssetSpeed;
        public int HeroAssetSpeed
        {
            get => _heroAssetSpeed;
            set => _heroAssetSpeed = value;
        }
        
        [SerializeField] private int _heroAssetChance;
        public int HeroAssetChance
        {
            get => _heroAssetChance;
            set => _heroAssetChance = value;
        }

        [Header("Other Attributes")] [SerializeField]
        private float _criticalChance;

        public float CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value;
        }

        [SerializeField] private float _criticalDamageMultiplier;

        public float CriticalDamageMultiplier
        {
            get => _criticalDamageMultiplier;
            set => _criticalDamageMultiplier = value;
        }

        [SerializeField] private float _accuracy;

        public float Accuracy
        {
            get => _accuracy;
            set => _accuracy = value;
        }

        [SerializeField] private float _resistance;

        public float Resistance
        {
            get => _resistance;
            set => _resistance = value;
        }

        [SerializeField] private float _totalDamageReduction;

        public float TotalDamageReduction
        {
            get => _totalDamageReduction;
            set => _totalDamageReduction = value;

        }

        [SerializeField] private float _criticalDamageReduction;

        public float CriticalDamageReduction
        {
            get => _criticalDamageReduction;
            set => _criticalDamageReduction = value;
        }





    }
}
