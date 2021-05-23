using System.Collections;
using Interfaces;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator DamageHero(int damageValue);
    }
}