using Logic;

namespace Interfaces
{
    public interface IPlayerChildrenReferences
    {
        IObjectList LivingHeroes { get; }
        IObjectList DeadHeroes { get; }
        IObjectList HeroSkillsList { get; }
        IObjectList PanelSkillsList { get; }
        IHeroPortraitList PanelPortraitList { get; }
        IHeroPortraitList HeroPortraitList { get; }


    }
}