using UnityEngine;

namespace Interfaces
{
    public interface IHeroPreviewVisual
    {
        
        IHero Hero { get; }
        Canvas PreviewCanvas { get; }

        Canvas StatusEffectCanvas { get; }

        GameObject StatusCanvasPanel { get; }
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