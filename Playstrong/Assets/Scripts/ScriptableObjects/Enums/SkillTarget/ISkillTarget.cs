﻿using System;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
   
    public interface ISkillTarget
    {
        void SetTargets(Action getValidTargets, Action getAllyTargets, Action getEnemyTargets);

        GameObject SetTargetGlows(IHero hero);


    }
}