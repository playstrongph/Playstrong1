using UnityEngine;

namespace Interfaces
{
    public interface IHeroPreviewVisual
    {
        
        IHeroObjectReferences HeroObjectReferences { get; }
        Canvas PreviewCanvas { get; }
        IHeroPreviewGraphic HeroPreviewGraphic { get; }
        IHeroPreviewName HeroPreviewName { get; }
        IHeroPreviewAttack HeroPreviewAttack { get; }
        IHeroPreviewHealth HeroPreviewHealth { get; }
        IHeroPreviewSpeed HeroPreviewSpeed { get; }

        IHeroPreviewChance HeroPreviewChance { get; }

        ILoadHeroPreviewVisuals LoadHeroPreviewVisuals { get; }

        Transform PreviewTransform { get; }


    }
}