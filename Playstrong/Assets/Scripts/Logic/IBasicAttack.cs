using System.Collections;
using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack
    {
        IHeroAction AttackAction { get; }

        List<int> FinalAttackModifiers { get; }

        List<float> CriticalFactor { get; }

        float GetCriticalFactor();
    }
}