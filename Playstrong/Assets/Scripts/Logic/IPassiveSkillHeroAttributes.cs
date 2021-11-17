using System.Collections;

namespace Logic
{
    public interface IPassiveSkillHeroAttributes
    {
        int Attack { get; set; }
        int Speed { get; set; }
        int Chance { get; set; }
        int CounterAttackChance { get; set; }
        int CriticalStrikeChance { get; set; }
        int CriticalStrikeResistance { get; set; }
        int DebuffResistance { get; set; }
        int AttackTargetResistance { get; set; }
        int CriticalDamageMultiplier { get; set; }
        IEnumerator DisablePassiveAttributes();
        IEnumerator EnablePassiveAttributes();
    }
}