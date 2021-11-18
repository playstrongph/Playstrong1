using System.Collections;

namespace Logic
{
    public interface IPassiveSkillHeroAttributes
    {
        int Attack { get; set; }
        int Speed { get; set; }
        int Chance { get; set; }
        
        //OTHER ATTRIBUTES
        
        //CHANCE
        int CounterAttackChance { get; set; }
        int CriticalStrikeChance { get; set; }

        int SkillChanceBonus { get; set; }

        //RESISTANCE
        int CriticalStrikeResistance { get; set; }
        int DebuffResistance { get; set; }
        int AttackTargetResistance { get; set; }
        
        //MULTIPLIERS
        int CriticalDamageMultiplier { get; set; }
        
        
        //METHODS
        IEnumerator DisablePassiveAttributes();
        IEnumerator EnablePassiveAttributes();
    }
}