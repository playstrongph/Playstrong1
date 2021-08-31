using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
        int OtherAttackDamage { get; set; }
        IEnumerator DealAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor);
        IEnumerator DealDirectDamage(IHero targetHero, int normalDamage, int penetrateChance); 
     
    }
}