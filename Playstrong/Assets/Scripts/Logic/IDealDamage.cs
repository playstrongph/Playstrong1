using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
       IEnumerator DealAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor);
       int OtherDamage { get; set; }

       IEnumerator DealDirectDamage(IHero targetHero, int normalDamage);
    }
}