using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
       IEnumerator DealDamageHero(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor);
       int OtherDamage { get; set; }
    }
}