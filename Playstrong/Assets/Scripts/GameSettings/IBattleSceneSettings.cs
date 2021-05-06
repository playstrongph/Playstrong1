using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace GameSettings
{
    public interface IBattleSceneSettings
    {
        IBranchLogic BranchLogic { get; }

        GameObject Player { get; }
        GameObject HeroObjectPrefab { get; }
        GameObject SkillObjectPrefab { get; }

        GameObject SkillPanelPrefab { get; }

        GameObject HeroPortraitPrefab { get; }

        ITeamHeroesAsset PlayerTeamHeroesAsset { get; }
        ITeamHeroesAsset EnemyTeamHeroesAsset { get; }

        Transform BattleSceneManagerTransform { get; }

        Transform AllyHeroesBoardLocation { get; }
        Transform EnemyHeroesBoardLocation { get; }

        Transform MainHeroPortraitLocation { get; }

        Transform PanelPortraitLocation { get; }

        Transform AllySkillsBoardLocation { get; }

        Transform EnemySkillsBoardLocation { get; }

        Transform AllyPanelSkillsLocation { get; }
        
        Transform EnemyPanelSkillsLocation { get; }

        Transform SkillPreviewLocation { get; }

        List<Transform> HeroPreviewLocations { get; }

        Transform PanelSkillPreviewLocation { get; }





    }
}