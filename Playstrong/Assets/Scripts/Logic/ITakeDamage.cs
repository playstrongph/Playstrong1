using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator DamageHero(int damageValue, IHero attacker);

        IEnumerator DamageHeroTest(int normalDamage, int criticalDamage, IHero attacker);

        List<IModifier> DamageModifiers { get; }

        void AddToDamageModifiersList(IModifier modifier);

        void RemoveFromDamageModifiersList(IModifier modifier);

    }
}