using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class OtherAttributes : MonoBehaviour, IOtherAttributes
    {   
        /// <summary>
        /// Damage Multipliers
        /// </summary>

        [Header("Damage Multipliers")] [SerializeField]
        private float _damageReduction = 0f;

        public float DamageReduction
        {
            get => _damageReduction;
            set => _damageReduction = value;
        }
        
        [SerializeField]
        private float _criticalDamageMultiplier = 100f;

        public float CriticalDamageMultiplier
        {
            get => _criticalDamageMultiplier;
            set => _criticalDamageMultiplier = value;
        }
        
        /// <summary>
        /// Hero Resistances
        /// </summary>
        
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
        
        [SerializeField]
        private float _skillChanceResistance = 0f;

        public float SkillChanceResistance
        {
            get => _skillChanceResistance;
            set => _skillChanceResistance = value;
            
        }
        
        [SerializeField]
        private float _resurrectResistance = 0f;

        public float ResurrectResistance
        {
            get => _resurrectResistance;
            set => _resurrectResistance = value;
            
        }
        
        [SerializeField]
        private float _counterAttackResistance = 0f;

        public float CounterAttackResistance
        {
            get => _counterAttackResistance;
            set => _counterAttackResistance = value;
            
        }

        [SerializeField] private float attackTargetResistance = 0f;

        public float AttackTargetResistance
        {
            get => attackTargetResistance;
            set => attackTargetResistance = value;
        }





        /// <summary>
        /// Hero Chances
        /// </summary>
        
        [Header("Hero Chances")]
        [SerializeField]
        private float _healChance = 100f;

        public float HealChance
        {
            get => _healChance;
            set => _healChance = value;
            
        }
        
        [SerializeField]
        private float _criticalStrikeChance = 0f;

        public float CriticalStrikeChance
        {
            get => _criticalStrikeChance;
            set => _criticalStrikeChance = value;
            
        }
        
        [SerializeField]
        private float _debuffChance = 100f;

        public float DebuffChance
        {
            get => _debuffChance;
            set => _debuffChance = value;
            
        }
        
        [SerializeField]
        private float _buffChance = 100f;

        public float BuffChance
        {
            get => _buffChance;
            set => _buffChance = value;
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
        
        [SerializeField]
        private float _counterAttackChance = 0f;

        public float CounterAttackChance
        {
            get => _counterAttackChance;
            set => _counterAttackChance = value;
        }
        
        [SerializeField] private float attackTargetChance = 100f;

        public float AttackTargetChance
        {
            get => attackTargetChance;
            set => attackTargetChance = value;
        }
        
        
        
        /// <summary>
        /// Base Damage Multipliers
        /// </summary>

        [Header("Damage Multipliers")]
        [Header("Base Values")] [SerializeField]
        private float _baseDamageReduction = 0f;

        public float BaseDamageReduction
        {
            get => _baseDamageReduction;
            set => _baseDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseCriticalDamageMultiplier = 100f;

        public float BaseCriticalDamageMultiplier
        {
            get => _baseCriticalDamageMultiplier;
            set => _baseCriticalDamageMultiplier = value;
        }
        
        /// <summary>
        /// Base Hero Resistances
        /// </summary>
        
        [Header("Hero Resistances")]
        
        [SerializeField]
        private float _baseHealResistance = 0f;

        public float BaseHealResistance
        {
            get => _baseHealResistance;
            set => _baseHealResistance = value;
        }
        
        [SerializeField]
        private float _baseCriticalStrikeResistance = 0f;

        public float BaseCriticalStrikeResistance
        {
            get => _baseCriticalStrikeResistance;
            set => _baseCriticalStrikeResistance = value;
        }
        
        [SerializeField]
        private float _baseDebuffResistance = 15f;

        public float BaseDebuffResistance
        {
            get => _baseDebuffResistance;
            set => _baseDebuffResistance = value;
        }
        
        [SerializeField]
        private float _baseBuffResistance = 0f;

        public float BaseBuffResistance
        {
            get => _baseBuffResistance;
            set => _baseBuffResistance = value;
            
        }
        
        [SerializeField]
        private float _baseSkillChanceResistance = 0f;

        public float BaseSkillChanceResistance
        {
            get => _baseSkillChanceResistance;
            set => _baseSkillChanceResistance = value;
        }
        
        [SerializeField]
        private float _baseResurrectResistance = 0f;

        public float BaseResurrectResistance
        {
            get => _baseResurrectResistance;
            set => _baseResurrectResistance = value;
            
        }
        
        [SerializeField]
        private float _baseCounterAttackResistance = 0f;

        public float BaseCounterAttackResistance
        {
            get => _baseCounterAttackResistance;
            set => _baseCounterAttackResistance = value;
        }
        
        [SerializeField] private float baseAttackTargetResistance = 0f;

        public float BaseAttackTargetResistance
        {
            get => baseAttackTargetResistance;
            set => baseAttackTargetResistance = value;
        }
        
        
        
        
        /// <summary>
        /// Base Hero Chances
        /// </summary>
        
        [Header("Hero Chances")]
        
        [SerializeField]
        private float _baseHealChance = 0f;

        public float BaseHealChance
        {
            get => _baseHealChance;
            set => _baseHealChance = value;
            
        }
        
        [SerializeField]
        private float _baseCriticalStrikeChance = 0f;

        public float BaseCriticalStrikeChance
        {
            get => _baseCriticalStrikeChance;
            set => _baseCriticalStrikeChance = value;
            
        }
        
        [SerializeField]
        private float _baseDebuffChance = 0f;

        public float BaseDebuffChance
        {
            get => _baseDebuffChance;
            set => _baseDebuffChance = value;
            
        }
        
        [SerializeField]
        private float _baseBuffChance = 0f;

        public float BaseBuffChance
        {
            get => _baseBuffChance;
            set => _baseBuffChance = value;
            
        }
        
        [SerializeField]
        private float _baseSkillChanceBonus = 0f;

        public float BaseSkillChanceBonus
        {
            get => _baseSkillChanceBonus;
            set => _baseSkillChanceBonus = value;
            
        }
        
        [SerializeField]
        private float _baseResurrectChance = 0f;

        public float BaseResurrectChance
        {
            get => _baseResurrectChance;
            set => _baseResurrectChance = value;
        }
        
        [SerializeField]
        private float _baseCounterAttackChance = 0f;

        public float BaseCounterAttackChance
        {
            get => _baseCounterAttackChance;
            set => _baseCounterAttackChance = value;
        }
        
        [SerializeField] private float baseAttackTargetChance = 100f;

        public float BaseAttackTargetChance
        {
            get => baseAttackTargetChance;
            set => baseAttackTargetChance = value;
        }
        
        
        /// <summary>
        /// Script References
        /// </summary>
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
    }
}
