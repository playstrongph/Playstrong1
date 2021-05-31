using System;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
   
    public interface ISkillTarget
    {
        void SetTargets(Action getValidTargets, Action getAllyTargets, Action getEnemyTargets);


    }
}
