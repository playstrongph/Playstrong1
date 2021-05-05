using Logic;

namespace Interfaces
{
    public interface IPlayer
    {
        IPlayerControllerEnumAsset PlayerControllerEnum { get; }
        IPlayerTypeEnumAsset PlayerTypeEnum { get; }
        IInitializePlayerHeroes InitializePlayerHeroes { get; }

        IInitializeHeroSkills InitializeHeroSkills { get; }
        
        IHeroesList LivingHeroes { get; }
        IHeroesList DeadHeroes { get; }

        IHeroesList HeroSkillsList { get; }

        IHeroPortraitList HeroPortraitList { get; }

        IHeroesList PanelSkillsList { get; }

        IHeroPortraitList PanelPortraitList { get; }

        ICreateHeroSkillReferences CreateHeroSkillReferences { get; }

        IInitializeHeroPortraits InitializeHeroPortraits { get; }

        ICreateHeroPortraitReferences CreateHeroPortraitReferences { get; }
        
        IInitializePanelPortraits InitializePanelPortraits { get; }

        ICreatePanelPortraitReferences CreatePanelPortraitReferences { get; }

        IInitializePanelSkills InitializePanelSkills { get; }

        ICreatePanelSkillReferences CreatePanelSkillReferences { get; }
    }
}