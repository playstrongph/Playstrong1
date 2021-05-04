using UnityEngine;

namespace Interfaces
{
    public interface IHeroPreviewVisual
    {
        
        IHeroPrefab HeroPrefab { get; }
        Canvas PreviewCanvas { get; }

        Canvas StatusCanvas { get; }
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