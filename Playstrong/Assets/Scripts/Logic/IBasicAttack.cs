using System.Collections;
using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack
    {
        List<float> UniqueAttackModifiers { get; }

        IEnumerator StartAttack(IHero thisHero, IHero targetHero);

        List<float> CriticalAttackModifiers { get; }

    }
}