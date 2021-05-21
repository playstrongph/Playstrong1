using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IGetAttackTargets
    {
        List<IHero> GetTargets();

        void EnableGlows();

        void DisableGlows();

    }
}