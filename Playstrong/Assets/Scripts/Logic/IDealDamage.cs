using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IDealDamage
    {
        int FinalDamageDealt { get; set; }
        IEnumerator DealDamageHero(IHero targetHero, int finalAttackValue);
    }
}