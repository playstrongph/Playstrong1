using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IGetAttackTargets
    {
        List<IHero> GetValidEnemyTargets();

        void EnableGlows();

        void DisableGlows();

    }
}