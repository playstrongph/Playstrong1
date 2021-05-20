using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IBasicAttackTargets
    {
        List<IHero> GetTargets();
        void ShowBasicAttackTargetsGlow();
        void HideBasicAttackTargetsGlow();
    }
}