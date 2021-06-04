using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
   
    public interface ISkillTarget
    {
        void SetTargetIndex(IGetSkillTargets _getSkillTargets);

        GameObject SetTargetGlows(IHero hero);


    }
}
