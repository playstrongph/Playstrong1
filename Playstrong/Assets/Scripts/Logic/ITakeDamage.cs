using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator DamageHeroTest(int normalDamage, int criticalDamage, IHero attacker);

    }
}