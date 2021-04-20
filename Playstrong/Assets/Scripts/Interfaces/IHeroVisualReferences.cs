using UnityEngine;

namespace Interfaces
{
    public interface IHeroVisualReferences
    {
        IHeroObjectReferences HeroObjectReferences { get; }
        Canvas HeroCanvas { get; }

        ITauntFrameAndGlow TauntFrameAndGlow { get; }

        INormalFrameAndGlow NormalFrameAndGlow { get; }

        ISetHeroGraphic HeroGraphic { get; }

        ISetAttackVisual AttackVisual { get; }

        ISetArmorVisual ArmorVisual { get; }

        ISetHealthVisual HealthVisual { get; }
        ISetEnergyVisual EnergyVisual { get; }
        
        

    }
}