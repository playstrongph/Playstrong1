using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
        int OtherAttackDamage { get; set; }
        IEnumerator DealDirectDamage(IHero targetHero, int normalDamage);
        IEnumerator DealSingleAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor);
        IEnumerator DealMultipleAttackDamage(IHero attackerHero, IHero targetHero, int attackPower,
            float criticalFactor);
    }
}