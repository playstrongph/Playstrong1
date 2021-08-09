namespace Logic
{
    public interface IOtherAttributes
    {   
        //Damage Multipliers
        float DamageReduction { get; set; }
        float CriticalDamageMultiplier { get; set; }
        
        //Hero Resistances
        float HealResistance { get; set; }
        float CriticalStrikeResistance { get; set; }
        float DebuffResistance { get; set; }
        float BuffResistance { get; set; }

        
        //Hero Chances
        float HealChance { get; set; }
        float CriticalStrikeChance { get; set; }
        float SkillChanceBonus { get; set; }
        float ResurrectChance { get; set; }
    }
}