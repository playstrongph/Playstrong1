namespace Logic
{
    public interface IOtherAttributes
    {
        float DamageReduction { get; set; }
        float DamageMultiplier { get; set; }
        float HealResistance { get; set; }
        float CriticalStrikeResistance { get; set; }
        float DebuffResistance { get; set; }
        float BuffResistance { get; set; }
        float CriticalStrikeChance { get; set; }
        float SkillChanceBonus { get; set; }
        float ResurrectChance { get; set; }
    }
}