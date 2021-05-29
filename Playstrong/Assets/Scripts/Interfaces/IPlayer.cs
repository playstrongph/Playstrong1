using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;

namespace Interfaces
{
    public interface IPlayer
    {
        IPlayerControllerEnumAsset PlayerControllerEnum { get; }
        IPlayerTypeEnumAsset PlayerTypeEnum { get; }
        ICoroutineTreesAsset GlobalTrees { get; }

        IPlayer OtherPlayer { get; set; }
        IInitializePlayerHeroes InitializePlayerHeroes { get; }

        IInitializeHeroSkills InitializeHeroSkills { get; }
        
        ILivingHeroes LivingHeroes { get; }
        IDeadHeroes DeadHeroes { get; }

        IHeroesSkills HeroesSkills { get; }

        IHeroesPortraits HeroesPortraits { get; }

        IPanelSkills PanelSkills { get; }

        IPanelPortraits PanelPortraits { get; }

        ICreateHeroSkillReferences CreateHeroSkillReferences { get; }

        IInitializeHeroPortraits InitializeHeroPortraits { get; }

        ICreateHeroPortraitReferences CreateHeroPortraitReferences { get; }
        
        IInitializePanelPortraits InitializePanelPortraits { get; }

        ICreatePanelPortraitReferences CreatePanelPortraitReferences { get; }

        IInitializePanelSkills InitializePanelSkills { get; }

        ICreatePanelSkillReferences CreatePanelSkillReferences { get; }

        IBattleSceneManager BattleSceneManager { get; }

    }
}