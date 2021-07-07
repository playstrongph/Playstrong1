using System.Collections;
using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack
    {
        IHeroAction AttackAction { get; }

        List<float> UniqueAttackModifiers { get; }

        List<float> CriticalMultipliers { get; }

        float GetCriticalFactor();
    }
}