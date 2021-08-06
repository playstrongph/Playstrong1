using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
        int FinalDamageDealt { get; set; }
        IEnumerator DealDamageHero(IHero attackerHero, IHero targetHero, int finalAttackValue);

        int OtherDamage { get; set; }
    }
}