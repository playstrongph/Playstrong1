using Logic;
using ScriptableObjects;
using Visual;

namespace Interfaces
{
    public interface IHeroPrefab
    {
        IHeroVisual HeroVisual { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        IHeroSkills Skills { get; }

        IHeroPortrait HeroPortrait { get; }

        IHeroPortrait PanelHeroPortrait { get; }

        IHeroSkills PanelSkillsReference { get; }


    }
}