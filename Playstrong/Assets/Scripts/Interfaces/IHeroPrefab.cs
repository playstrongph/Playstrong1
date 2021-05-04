using Logic;
using ScriptableObjects;
using Visual;

namespace Interfaces
{
    public interface IHeroPrefab
    {
        IHeroVisualReferences HeroVisualReferences { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        IHeroSkillsReference SkillsReference { get; }

        IHeroPortrait HeroPortrait { get; }

        IHeroPortrait PanelHeroPortrait { get; }

        IHeroSkillsReference PanelSkillsReference { get; }


    }
}