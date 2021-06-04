using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    public interface IGetSkillTargets
    {
        List<IHero> GetValidTargets();

        void EnableGlows();

        void DisableGlows();

        int TargetIndex { get; set; }


    }
}