using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamageTest
    {
        /// <summary>
        /// Called by Attack Method
        /// </summary>
        IEnumerator MultiAttackDealDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
        IEnumerator SingleAttackDealDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
    }
}