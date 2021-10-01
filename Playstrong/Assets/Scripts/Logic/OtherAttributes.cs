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

        [Header("Damage Reduction")] [SerializeField]
        private float _takeAllDamageReduction = 0f;

        public float TakeAllDamageReduction
        {
            get => _takeAllDamageReduction;
            set => _takeAllDamageReduction = value;
        }
        
        [SerializeField]
        private float _directDamageReduction = 0f;
        public float DirectDamageReduction
        {
            get => _directDamageReduction;
            set => _directDamageReduction = value;
        }
        
        
        [SerializeField]
        private float _takeSingleAttackDamageReduction = 0f;
        public float TakeSingleAttackDamageReduction
        {
            get => _takeSingleAttackDamageReduction;
            set => _takeSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _takeMultiAttackDamageReduction = 0f;
        public float TakeMultiAttackDamageReduction
        {
            get => _takeMultiAttackDamageReduction;
            set => _takeMultiAttackDamageReduction = value;
        }

        [SerializeField] private float _takeSkillDamageReduction = 0f;

        public float TakeSkillDamageReduction
        {
            get => _takeSkillDamageReduction;
            set => _takeSkillDamageReduction = value;
        }
        
        [SerializeField] private float _takeNonSkillDamageReduction = 0f;

        public float TakeNonSkillDamageReduction
        {
            get => _takeNonSkillDamageReduction;
            set => _takeNonSkillDamageReduction = value;
        }

        [Header("Damage Multipliers")][SerializeField]
        private float _criticalDamageMultiplier = 100f;

        public float CriticalDamageMultiplier
        {
            get => _criticalDamageMultiplier;
            set => _criticalDamageMultiplier = value;
        }
        
        [SerializeField]
        private float _otherDamageMultiplier = 0f;

        public float OtherDamageMultiplier
        {
            get => _otherDamageMultiplier;
            set => _otherDamageMultiplier = value;
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
        
        [SerializeField] private float penetrateArmorResistance = 0f;

        public float PenetrateArmorResistance
        {
            get => penetrateArmorResistance;
            set => penetrateArmorResistance = value;
        }
        
        [SerializeField] private float boostEnergyResistance = 0f;

        public float BoostEnergyResistance
        {
            get => boostEnergyResistance;
            set => boostEnergyResistance = value;
        }
        
        [SerializeField] private float reduceEnergyResistance = 0f;

        public float ReduceEnergyResistance
        {
            get => reduceEnergyResistance;
            set => reduceEnergyResistance = value;
        }
        
        [SerializeField] private float heroInabilityResistance = 0f;

        public float HeroInabilityResistance
        {
            get => heroInabilityResistance;
            set => heroInabilityResistance = value;
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
        
        [SerializeField] private float penetrateArmorChance = 0f;

        public float PenetrateArmorChance
        {
            get => penetrateArmorChance;
            set => penetrateArmorChance = value;
        }
        
        [SerializeField] private float boostEnergyChance = 0f;

        public float BoostEnergyChance
        {
            get => boostEnergyChance;
            set => boostEnergyChance = value;
        }
        
        [SerializeField] private float reduceEnergyChance = 0f;

        public float ReduceEnergyChance
        {
            get => reduceEnergyChance;
            set => reduceEnergyChance = value;
        }
        
        [SerializeField] private float heroInabilityChance = 0f;

        public float HeroInabilityChance
        {
            get => heroInabilityChance;
            set => heroInabilityChance = value;
        }
        
        
        
        /// <summary>
        /// Base Damage Multipliers
        /// </summary>

        [Header("Base Damage Reduction")]
        [Header("Base Values")] [SerializeField]
        private float _baseDamageReduction = 0f;

        public float BaseDamageReduction
        {
            get => _baseDamageReduction;
            set => _baseDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseDirectDamageReduction = 0f;
        public float BaseDirectDamageReduction
        {
            get => _baseDirectDamageReduction;
            set => _baseDirectDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseSingleAttackDamageReduction = 0f;
        public float BaseSingleAttackDamageReduction
        {
            get => _baseSingleAttackDamageReduction;
            set => _baseSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseMultipleAttackDamageReduction = 0f;
        public float BaseMultipleAttackDamageReduction
        {
            get => _baseMultipleAttackDamageReduction;
            set => _baseMultipleAttackDamageReduction = value;
        }
        
        [Header("Base Damage Multipliers")]
        
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
        
        [Header("Base Hero Resistances")]
        
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
        
        [SerializeField] private float basePenetrateArmorResistance = 0f;

        public float BasePenetrateArmorResistance
        {
            get => basePenetrateArmorResistance;
            set => basePenetrateArmorResistance = value;
        }
        
        [SerializeField] private float baseBoostEnergyResistance = 0f;

        public float BaseBoostEnergyResistance
        {
            get => baseBoostEnergyResistance;
            set => baseBoostEnergyResistance = value;
        }
        
        [SerializeField] private float baseReduceEnergyResistance = 0f;
        public float BaseReduceEnergyResistance
        {
            get => baseReduceEnergyResistance;
            set => baseReduceEnergyResistance = value;
        }
        
        [SerializeField] private float baseHeroInabilityResistance = 0f;

        public float BaseHeroInabilityResistance
        {
            get => baseHeroInabilityResistance;
            set => baseHeroInabilityResistance = value;
        }
        
        
        
        
        /// <summary>
        /// Base Hero Chances
        /// </summary>
        
        [Header("Base Hero Chances")]
        
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
        
        [SerializeField] private float basePenetrateArmorChance = 0f;

        public float BasePenetrateArmorChance
        {
            get => basePenetrateArmorChance;
            set => basePenetrateArmorChance = value;
        }
        
        [SerializeField] private float baseBoostEnergyChance = 0f;

        public float BaseBoostEnergyChance
        {
            get => baseBoostEnergyChance;
            set => baseBoostEnergyChance = value;
        }
        
        [SerializeField] private float baseReduceEnergyChance = 0f;
        public float BaseReduceEnergyChance
        {
            get => baseReduceEnergyChance;
            set => baseReduceEnergyChance = value;
        }
        
        [SerializeField] private float baseHeroInabilityChance = 0f;

        public float BaseHeroInabilityChance
        {
            get => baseHeroInabilityChance;
            set => baseHeroInabilityChance = value;
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
