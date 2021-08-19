using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator TakeAllDamage(int normalDamage, int criticalDamage);

        int FinalDamage { get; }


    }
}