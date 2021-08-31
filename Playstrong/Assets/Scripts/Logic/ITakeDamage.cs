using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        //TODO: Delete After Implem of damageTypes
        IEnumerator TakeAttackDamage(int normalDamage, int criticalDamage, IHero attacker);
        //TODO: Delete After IMplem of damageTypes
        int FinalDamage { get; }
        
        int DirectDamage { get; }

        int SingleAttackDamage { get; }

        int MultipleAttackDamage { get; }

        IEnumerator TakeSingleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero);

        IEnumerator TakeMultipleAttackDamage(int normalDamage, int criticalDamage, IHero attackerHero);
        
        IEnumerator TakeDirectDamage(int normalDamage, int totalEnhancedDamage, int penetrateChance);
        
        



    }
}