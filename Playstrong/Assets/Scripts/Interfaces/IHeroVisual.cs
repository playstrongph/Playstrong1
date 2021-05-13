using UnityEngine;
using Visual;

namespace Interfaces
{
    public interface IHeroVisual
    {
        IHero Hero { get; }
        Canvas HeroCanvas { get; }

        ITauntFrameAndGlow TauntFrameAndGlow { get; }

        INormalFrameAndGlow NormalFrameAndGlow { get; }

        ISetHeroGraphic HeroGraphic { get; }

        ISetAttackVisual AttackVisual { get; }

        ISetArmorVisual ArmorVisual { get; }

        ISetHealthVisual HealthVisual { get; }
        ISetEnergyVisual EnergyVisual { get; }

        ILoadHeroVisuals LoadHeroVisuals { get; }

        ISetHeroFrameAndGlow SetHeroFrameAndGlow { get; }



    }
}