using Logic;

namespace Interfaces
{
    public interface IPlayerChildrenReferences
    {
        IHeroesList LivingHeroes { get; }
        IHeroesList DeadHeroes { get; }

        IHeroesList HeroSkillsList { get; }

        IHeroPortraitList HeroPortraitList { get; }

        IHeroesList PanelSkillsList { get; }

        IHeroPortraitList PanelPortraitList { get; }


    }
}