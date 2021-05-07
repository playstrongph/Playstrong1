using Logic;

namespace Interfaces
{
    public interface IPlayer
    {
        IPlayerControllerEnumAsset PlayerControllerEnum { get; }
        IPlayerTypeEnumAsset PlayerTypeEnum { get; }
        IInitializePlayerHeroes InitializePlayerHeroes { get; }

        IInitializeHeroSkills InitializeHeroSkills { get; }
        
        ILivingHeroes LivingHeroes { get; }
        IDeadHeroes DeadHeroes { get; }

        IObjectList HeroSkillsList { get; }

        IObjectList HeroPortraitList { get; }

        IObjectList PanelSkillsList { get; }

        IObjectList PanelPortraitList { get; }

        ICreateHeroSkillReferences CreateHeroSkillReferences { get; }

        IInitializeHeroPortraits InitializeHeroPortraits { get; }

        ICreateHeroPortraitReferences CreateHeroPortraitReferences { get; }
        
        IInitializePanelPortraits InitializePanelPortraits { get; }

        ICreatePanelPortraitReferences CreatePanelPortraitReferences { get; }

        IInitializePanelSkills InitializePanelSkills { get; }

        ICreatePanelSkillReferences CreatePanelSkillReferences { get; }
       
    }
}