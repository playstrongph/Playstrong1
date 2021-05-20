using Logic;
using ScriptableObjects;
using Visual;

namespace Interfaces
{
    public interface IHero
    {

        string HeroName { get; set; }
        IHeroVisual HeroVisual { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        IHeroSkills Skills { get; }

        IHeroPortrait HeroPortrait { get; }

        IPanelHeroPortrait PanelHeroPortrait { get; }

        PanelHeroSkills PanelHeroSkills { get; }

        ILivingHeroes LivingHeroes { get; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }
        ITargetHero TargetHero { get; }


    }
}