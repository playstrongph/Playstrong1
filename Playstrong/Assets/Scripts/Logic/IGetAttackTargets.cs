using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IGetAttackTargets
    {
        List<IHero> GetValidTargets();

        void EnableGlows();

        void DisableGlows();

    }
}