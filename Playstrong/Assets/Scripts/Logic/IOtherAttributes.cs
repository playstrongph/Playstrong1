namespace Logic
{
    public interface IOtherAttributes
    {   
        /// <summary>
        /// Damage Multipliers
        /// </summary>
        float DamageReduction { get; set; }
        float CriticalDamageMultiplier { get; set; }
        
       /// <summary>
       /// Hero Resistances
       /// </summary>
        float HealResistance { get; set; }
        float CriticalStrikeResistance { get; set; }
        float DebuffResistance { get; set; }
        float BuffResistance { get; set; }
        float SkillChanceResistance { get; set; }
        float ResurrectResistance { get; set; }
        
        /// <summary>
        /// Hero Chances
        /// </summary>
        float HealChance { get; set; }
        float CriticalStrikeChance { get; set; }
        float DebuffChance { get; set; }
        float BuffChance { get; set; }
        float SkillChanceBonus { get; set; }
        float ResurrectChance { get; set; }

        /// <summary>
        /// Base Damage Multipliers
        /// </summary>
        float BaseDamageReduction { get; set; }
        float BaseCriticalDamageMultiplier { get; set; }
        
        /// <summary>
        /// Base Hero Resistances
        /// </summary>
        float BaseHealResistance { get; set; }
        float BaseCriticalStrikeResistance { get; set; }
        float BaseDebuffResistance { get; set; }
        float BaseBuffResistance { get; set; }
        float BaseSkillChanceResistance { get; set; }
        float BaseResurrectResistance { get; set; }
        
        /// <summary>
        /// Base Hero Chances
        /// </summary>
        float BaseHealChance { get; set; }
        float BaseCriticalStrikeChance { get; set; }
        float BaseDebuffChance { get; set; }
        float BaseBuffChance { get; set; }
        float BaseSkillChanceBonus { get; set; }
        float BaseResurrectChance { get; set; }



    }
}