using Logic;
using ScriptableObjects;
using Visual;

namespace Interfaces
{
    public interface IHeroObjectReferences
    {
        IHeroVisualReferences HeroVisualReferences { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogicReferences HeroLogicReferences { get; }

        IHeroSkillsReference SkillsReference { get; }

        IHeroPortrait HeroPortrait { get; }


    }
}