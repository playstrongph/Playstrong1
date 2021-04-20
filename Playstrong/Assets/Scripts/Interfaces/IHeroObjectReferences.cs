using ScriptableObjects;

namespace Interfaces
{
    public interface IHeroObjectReferences
    {
        IHeroVisualReferences HeroVisualReferences { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }
    }
}