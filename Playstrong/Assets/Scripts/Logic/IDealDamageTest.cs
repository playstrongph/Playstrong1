using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamageTest
    {
        /// <summary>
        /// Called by Attack Method
        /// </summary>
        IEnumerator AttackDealDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
    }
}