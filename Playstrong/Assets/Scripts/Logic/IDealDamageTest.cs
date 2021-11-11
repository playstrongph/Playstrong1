using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamageTest
    {
        /// <summary>
        /// Called by Attack Method
        /// </summary>
        IEnumerator DealMultiAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
        IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);

        IEnumerator DealNonAttackSkillDamage(IHero attackerHero, IHero targetHero, int nonAttackSkillDamage,
            float skillIgnoreArmorChance);

        //For non-attack (skills) sources of damage such as status effects and weapons
        IEnumerator DealNonSkillDamage(IHero targetHero, int nonSkillDamage, float ignoreArmorChance);
    }
}