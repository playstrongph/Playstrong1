using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator DamageHero(int damageValue);

        List<IModifier> DamageModifiers { get; }

        void AddToDamageModifiersList(IModifier modifier);

        void RemoveFromDamageModifiersList(IModifier modifier);
    }
}