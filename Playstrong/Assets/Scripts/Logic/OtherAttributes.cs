using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class OtherAttributes : MonoBehaviour, IOtherAttributes
    {

        [Header("Damage Multipliers")] [SerializeField]
        private float _damageReduction = 0f;

        public float DamageReduction
        {
            get => _damageReduction;
            set => _damageReduction = value;
        }
        
        [SerializeField]
        private float _damageMultiplier = 0f;

        public float DamageMultiplier
        {
            get => _damageMultiplier;
            set => _damageMultiplier = value;
        }
        
        [Header("Hero Resistances")]
        
        [SerializeField]
        private float _healResistance = 0f;

        public float HealResistance
        {
            get => _healResistance;
            set => _healResistance = value;
        }
        
        [SerializeField]
        private float _criticalStrikeResistance = 0f;

        public float CriticalStrikeResistance
        {
            get => _criticalStrikeResistance;
            set => _criticalStrikeResistance = value;
        }
        
        [SerializeField]
        private float _debuffResistance = 15f;

        public float DebuffResistance
        {
            get => _debuffResistance;
            set => _debuffResistance = value;
        }
        
        [SerializeField]
        private float _buffResistance = 0f;

        public float BuffResistance
        {
            get => _buffResistance;
            set => _buffResistance = value;
            
        }
        
        [Header("Hero Chances")]
        [SerializeField]
        private float _criticalStrikeChance = 0f;

        public float CriticalStrikeChance
        {
            get => _criticalStrikeChance;
            set => _criticalStrikeChance = value;
            
        }
        
        [SerializeField]
        private float _skillChanceBonus = 0f;

        public float SkillChanceBonus
        {
            get => _skillChanceBonus;
            set => _skillChanceBonus = value;
            
        }
        
        [SerializeField]
        private float _resurrectChance = 0f;

        public float ResurrectChance
        {
            get => _resurrectChance;
            set => _resurrectChance = value;
        }
        
        //Script References
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
    }
}
