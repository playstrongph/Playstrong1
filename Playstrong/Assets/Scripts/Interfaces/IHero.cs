using Logic;
using ScriptableObjects;
using Visual;

namespace Interfaces
{
    public interface IHero
    {
        IHeroVisual HeroVisual { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        IHeroSkills Skills { get; }

        IHeroPortrait HeroPortrait { get; }

        IPanelHeroPortrait PanelHeroPortrait { get; }

        IHeroSkills PanelHeroSkills { get; }


    }
}