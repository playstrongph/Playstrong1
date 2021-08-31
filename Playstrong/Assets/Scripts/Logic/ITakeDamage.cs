using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Modifiers;

namespace Logic
{
    public interface ITakeDamage
    {
        IEnumerator TakeAttackDamage(int normalDamage, int criticalDamage, IHero attacker);
        IEnumerator TakeDirectDamage(int normalDamage, int totalEnhancedDamage, int penetrateChance);
        int FinalDamage { get; }
        
        int DirectDamage { get; }

        int SingleAttackDamage { get; }

        int MultipleAttackDamage { get; }



    }
}