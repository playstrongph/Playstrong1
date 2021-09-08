namespace Logic
{
    public interface IOtherAttributes
    {   
        /// <summary>
        /// Damage Reduction
        /// </summary>
        float DamageReduction { get; set; }

        float DirectDamageReduction { get; set; }

        float SingleAttackDamageReduction { get; set; }
        float MultipleAttackDamageReduction { get; set; }
        
        /// <summary>
        /// Damage Multipliers
        /// </summary>
        float CriticalDamageMultiplier { get; set; }

        float OtherDamageMultiplier { get; set; }

        /// <summary>
       /// Hero Resistances
       /// </summary>
        float HealResistance { get; set; }
        float CriticalStrikeResistance { get; set; }
        float DebuffResistance { get; set; }
        float BuffResistance { get; set; }
        float SkillChanceResistance { get; set; }
        float ResurrectResistance { get; set; }
        float CounterAttackResistance { get; set; }
        float AttackTargetResistance { get; set; }
        float PenetrateArmorResistance { get; set; }
        float BoostEnergyResistance { get; set; }

        float ReduceEnergyResistance { get; set; }

        float HeroInabilityResistance { get; set; }

        /// <summary>
        /// Hero Chances
        /// </summary>
        float HealChance { get; set; }
        float CriticalStrikeChance { get; set; }
        float DebuffChance { get; set; }
        float BuffChance { get; set; }
        float SkillChanceBonus { get; set; }
        float ResurrectChance { get; set; }
        float CounterAttackChance { get; set;}
        float AttackTargetChance { get; set; }
        float PenetrateArmorChance { get; set; }
        float BoostEnergyChance { get; set; }
        float ReduceEnergyChance { get; set; }
        float HeroInabilityChance { get; set; }

        /// <summary>
        /// Base Damage Reduction
        /// </summary>
        float BaseDamageReduction { get; set; }
        float BaseDirectDamageReduction { get; set; }
        float BaseSingleAttackDamageReduction { get; set; }
        float BaseMultipleAttackDamageReduction { get; set; }
        
        /// <summary>
        /// Base Damage Multipliers
        /// </summary>
        float BaseCriticalDamageMultiplier { get; set;}
        float BaseAttackTargetChance { get; set; }

        /// <summary>
        /// Base Hero Resistances
        /// </summary>
        float BaseHealResistance { get; set; }
        float BaseCriticalStrikeResistance { get; set; }
        float BaseDebuffResistance { get; set; }
        float BaseBuffResistance { get; set; }
        float BaseSkillChanceResistance { get; set; }
        float BaseResurrectResistance { get; set; }
        float BaseCounterAttackResistance { get; set; }
        float BaseAttackTargetResistance { get; set; }
        float BasePenetrateArmorResistance { get; set; }
        float BaseBoostEnergyResistance { get; set; }
        float BaseReduceEnergyResistance { get; set; }
        float BaseHeroInabilityResistance { get; set; }

        /// <summary>
        /// Base Hero Chances
        /// </summary>
        float BaseHealChance { get; set; }
        float BaseCriticalStrikeChance { get; set; }
        float BaseDebuffChance { get; set; }
        float BaseBuffChance { get; set; }
        float BaseSkillChanceBonus { get; set; }
        float BaseResurrectChance { get; set; }
        float BaseCounterAttackChance { get; set; }
        float BasePenetrateArmorChance { get; set; }
        float BaseBoostEnergyChance { get; set; }
        float BaseReduceEnergyChance { get; set; }
        float BaseHeroInabilityChance { get; set; }



    }
}