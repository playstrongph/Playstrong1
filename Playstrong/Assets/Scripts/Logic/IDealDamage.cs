using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
       IEnumerator DealAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor);
       int OtherAttackDamage { get; set; }
       IEnumerator DealDirectDamage(IHero targetHero, int normalDamage);
       IEnumerator DealDirectDamageIgnoreArmor(IHero targetHero, int normalDamage);
    }
}