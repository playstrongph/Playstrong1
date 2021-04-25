﻿using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameSettings
{
    public interface IBattleSceneSettings
    {
        IBranchLogic BranchLogic { get; }
        GameObject HeroObjectPrefab { get; }
        GameObject SkillObjectPrefab { get; }
        ITeamHeroesAsset PlayerTeamHeroesAsset { get; }
        ITeamHeroesAsset EnemyTeamHeroesAsset { get; }

        Transform AllyHeroesBoardLocation { get; }
        Transform EnemyHeroesBoardLocation { get; }

        List<Transform> PreviewLocations { get; }

    }
}