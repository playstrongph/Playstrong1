using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameSettings
{
    public interface IBattleSceneSettings
    {
        IBranchLogic BranchLogic { get; }
        GameObject HeroObjectPrefab { get; }
        GameObject SkillObjectPrefab { get; }

        GameObject SkillPanelPrefab { get; }
        
        ITeamHeroesAsset PlayerTeamHeroesAsset { get; }
        ITeamHeroesAsset EnemyTeamHeroesAsset { get; }

        Transform AllyHeroesBoardLocation { get; }
        Transform EnemyHeroesBoardLocation { get; }

        Transform AllySkillsBoardLocation { get; }

        Transform EnemySkillsBoardLocation { get; }

        List<Transform> HeroPreviewLocations { get; }
        
        

    }
}