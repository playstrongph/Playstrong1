using Logic;

namespace Interfaces
{
    public interface IPlayer
    {
        IPlayerControllerEnumAsset PlayerControllerEnum { get; }
        IPlayerTypeEnumAsset PlayerTypeEnum { get; }

        ICoroutineTree LogicTree { get; set; }
        ICoroutineTree VisualTree { get; set; }

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
       
    }
}