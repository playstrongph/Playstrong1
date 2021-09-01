using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {

        int DirectDamage { get; }

        int FinalDamage { get; }

        int SingleAttackDamage { get; }

        int MultipleAttackDamage { get; }

        IEnumerator TakeSingleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero);

        IEnumerator TakeMultipleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero);
        
        IEnumerator TakeDirectDamage(int normalDamage, int criticalDamage, int penetrateChance);
        
        



    }
}