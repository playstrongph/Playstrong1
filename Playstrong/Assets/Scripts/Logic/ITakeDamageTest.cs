using System.Collections;
using Interfaces;

namespace Logic
{
    public interface ITakeDamageTest
    {
        int FinalDamage { get; }
        int DirectDamage { get; }
        int SingleAttackDamage { get; }
        int MultipleAttackDamage { get; }
        IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage, IHero attackerHero);
        IEnumerator TakeMultipleAttackDamage(int nonCriticalDamage, int criticalDamage, IHero attackerHero);
        IEnumerator TakeDirectDamage(int nonCriticalDamage, int criticalDamage, int ignoreArmorChance);
    }
}