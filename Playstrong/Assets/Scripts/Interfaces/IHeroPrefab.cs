using Logic;
using ScriptableObjects;
using UnityEngine;
using Visual;

namespace Interfaces
{
    public interface IHeroPrefab
    {
        IHeroVisual HeroVisual { get; }
        IBuffsVisual BuffsVisual { get; }
        IHeroPreviewVisual HeroPreviewVisual { get; }

        IHeroLogic HeroLogic { get; }

        ISkillsList Skills { get; set; }

        IHeroPortrait HeroPortrait { get; }

        IHeroPortrait PanelHeroPortrait { get; }

        IHeroSkills PanelHeroSkills { get; }
        
        Transform Transform { get; }


    }
}