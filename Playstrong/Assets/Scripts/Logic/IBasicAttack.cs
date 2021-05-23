using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack
    {
        IEnumerator BasicAttackHero(IHero targetHero);
    }
}