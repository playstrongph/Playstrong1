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

        [Header("Obsolete Damage Reduction")] 
        [SerializeField]
        private float directDamageReduction = 0f;
        public float DirectDamageReduction
        {
            get => directDamageReduction;
            set => directDamageReduction = value;
        }

        [Header("Fighting Spirit")] [SerializeField]
        private int fightingSpirit;

        public int FightingSpirit
        {
            get => fightingSpirit;
            set => fightingSpirit = value;
        }

        [Header("Take Damage Reduction")] 
        [SerializeField]
        private float takeAllDamageReduction = 0f;
        public float TakeAllDamageReduction
        {
            get => takeAllDamageReduction;
            set => takeAllDamageReduction = value;
        }

        [SerializeField]
        private float takeSingleAttackDamageReduction = 0f;
        public float TakeSingleAttackDamageReduction
        {
            get => takeSingleAttackDamageReduction;
            set => takeSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float takeMultiAttackDamageReduction = 0f;
        public float TakeMultiAttackDamageReduction
        {
            get => takeMultiAttackDamageReduction;
            set => takeMultiAttackDamageReduction = value;
        }

        [SerializeField] private float takeSkillDamageReduction = 0f;

        public float TakeSkillDamageReduction
        {
            get => takeSkillDamageReduction;
            set => takeSkillDamageReduction = value;
        }
        
        [SerializeField] private float takeNonSkillDamageReduction = 0f;

        public float TakeNonSkillDamageReduction
        {
            get => takeNonSkillDamageReduction;
            set => takeNonSkillDamageReduction = value;
        }
        
        
        //DEAL DAMAGE REDUCTION
        [Header("Deal Damage Reduction")] 
        [SerializeField]
        private float dealAllDamageReduction = 0f;
        public float DealAllDamageReduction
        {
            get => dealAllDamageReduction;
            set => dealAllDamageReduction = value;
        }

        [SerializeField]
        private float dealSingleAttackDamageReduction = 0f;
        public float DealSingleAttackDamageReduction
        {
            get => dealSingleAttackDamageReduction;
            set => dealSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float dealMultiAttackDamageReduction = 0f;
        public float DealMultiAttackDamageReduction
        {
            get => dealMultiAttackDamageReduction;
            set => dealMultiAttackDamageReduction = value;
        }

        [SerializeField] private float dealSkillDamageReduction = 0f;

        public float DealSkillDamageReduction
        {
            get => dealSkillDamageReduction;
            set => dealSkillDamageReduction = value;
        }
        
        [SerializeField] private float dealNonSkillDamageReduction = 0f;

        public float DealNonSkillDamageReduction
        {
            get => dealNonSkillDamageReduction;
            set => dealNonSkillDamageReduction = value;
        }

        [Header("Damage Multipliers")][SerializeField]
        private float criticalDamageMultiplier = 100f;

        public float CriticalDamageMultiplier
        {
            get => criticalDamageMultiplier;
            set => criticalDamageMultiplier = value;
        }
        
        [SerializeField]
        private float otherDamageMultiplier = 0f;

        public float OtherDamageMultiplier
        {
            get => otherDamageMultiplier;
            set => otherDamageMultiplier = value;
        }
        
        /// <summary>
        /// Hero Resistances
        /// </summary>
        
        [Header("Hero Resistances")]
        
        [SerializeField]
        private float healResistance = 0f;

        public float HealResistance
        {
            get => healResistance;
            set => healResistance = value;
        }
        
        [SerializeField]
        private float criticalStrikeResistance = 0f;

        public float CriticalStrikeResistance
        {
            get => criticalStrikeResistance;
            set => criticalStrikeResistance = value;
        }
        
        [SerializeField]
        private float debuffResistance = 15f;

        public float DebuffResistance
        {
            get => debuffResistance;
            set => debuffResistance = value;
        }
        
        [SerializeField]
        private float buffResistance = 0f;

        public float BuffResistance
        {
            get => buffResistance;
            set => buffResistance = value;
            
        }
        
        [SerializeField]
        private float skillChanceResistance = 0f;

        public float SkillChanceResistance
        {
            get => skillChanceResistance;
            set => skillChanceResistance = value;
            
        }
        
        [SerializeField]
        private float resurrectResistance = 0f;

        public float ResurrectResistance
        {
            get => resurrectResistance;
            set => resurrectResistance = value;
            
        }
        
        [SerializeField]
        private float counterAttackResistance = 0f;

        public float CounterAttackResistance
        {
            get => counterAttackResistance;
            set => counterAttackResistance = value;
            
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
        
        [SerializeField] private float energyUpResistance = 0f;

        public float EnergyUpResistance
        {
            get => energyUpResistance;
            set => energyUpResistance = value;
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
        [Header("Base Values")] 
        
        //TODO: For cleanup
        [SerializeField]
        private float _baseDirectDamageReduction = 0f;
        public float BaseDirectDamageReduction
        {
            get => _baseDirectDamageReduction;
            set => _baseDirectDamageReduction = value;
        }
        
        //TAKE DAMAGE REDUCTION
        [SerializeField]
        private float _baseTakeAllDamageReduction = 0f;

        public float BaseTakeAllDamageReduction
        {
            get => _baseTakeAllDamageReduction;
            set => _baseTakeAllDamageReduction = value;
        }

        [SerializeField]
        private float _baseTakeSingleAttackDamageReduction = 0f;
        public float BaseTakeSingleAttackDamageReduction
        {
            get => _baseTakeSingleAttackDamageReduction;
            set => _baseTakeSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseTakeMultiAttackDamageReduction = 0f;
        public float BaseTakeMultiAttackDamageReduction
        {
            get => _baseTakeMultiAttackDamageReduction;
            set => _baseTakeMultiAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseTakeSkillDamageReduction = 0f;
        public float BaseTakeSkillDamageReduction
        {
            get => _baseTakeSkillDamageReduction;
            set => _baseTakeSkillDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseTakeNonSkillDamageReduction = 0f;
        public float BaseTakeNonSkillDamageReduction
        {
            get => _baseTakeNonSkillDamageReduction;
            set => _baseTakeNonSkillDamageReduction = value;
        }
        
        //DEAL DAMAGE REDUCTION
        [SerializeField]
        private float _baseDealAllDamageReduction = 0f;

        public float BaseDealAllDamageReduction
        {
            get => _baseDealAllDamageReduction;
            set => _baseDealAllDamageReduction = value;
        }

        [SerializeField]
        private float _baseDealSingleAttackDamageReduction = 0f;
        public float BaseDealSingleAttackDamageReduction
        {
            get => _baseDealSingleAttackDamageReduction;
            set => _baseDealSingleAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseDealMultiAttackDamageReduction = 0f;
        public float BaseDealMultiAttackDamageReduction
        {
            get => _baseDealMultiAttackDamageReduction;
            set => _baseDealMultiAttackDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseDealSkillDamageReduction = 0f;
        public float BaseDealSkillDamageReduction
        {
            get => _baseDealSkillDamageReduction;
            set => _baseDealSkillDamageReduction = value;
        }
        
        [SerializeField]
        private float _baseDealNonSkillDamageReduction = 0f;
        public float BaseDealNonSkillDamageReduction
        {
            get => _baseDealNonSkillDamageReduction;
            set => _baseDealNonSkillDamageReduction = value;
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
