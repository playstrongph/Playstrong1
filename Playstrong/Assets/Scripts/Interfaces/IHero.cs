using System.Collections.Generic;
using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Visual;

namespace Interfaces
{
    public interface IHero
    {

        string HeroName { get; set; }
        IHeroVisual HeroVisual { get; }

        IHeroStatusEffects HeroStatusEffects { get; }
        IStatusEffectsVisual StatusEffectsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        IHeroSkills HeroSkills { get; }

        IHeroPortrait HeroPortrait { get; }

        IPanelHeroPortrait PanelHeroPortrait { get; }

        PanelHeroSkills PanelHeroSkills { get; }

        ILivingHeroes LivingHeroes { get; }

        IDeadHeroes DeadHeroes { get; }

        ICoroutineTreesAsset CoroutineTreesAsset { get; }
        ITargetHero TargetHero { get; }

        Transform HeroTransform { get; }

        IDamageEffect DamageEffect { get; }

        List<IHero> AllAllyHeroes { get; }
        
        List<IHero> AllOtherAllyHeroes { get;  }

        List<IHero> GetAllLivingAllyHeroes();

        List<IHero> GetAllOtherLivingAllyHeroes();
        
        //TEST
        void ShuffleAllLivingAllyHeroes();

        void ShuffleOtherLivingAllyHeroes();





    }
}