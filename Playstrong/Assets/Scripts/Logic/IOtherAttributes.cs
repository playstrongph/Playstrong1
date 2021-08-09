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
        
        
        
        
        
    }
}