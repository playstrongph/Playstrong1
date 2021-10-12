using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffectAsset
    {
        void ApplyStatusEffect(IHero hero);
        void UnapplyStatusEffect(IHero hero);

        void ApplyStackingEffect(IHero hero);

        void UnapplyStackingEffect(IHero hero);

        string Name { get; }

        string Description { get; }

        Sprite Icon { get; }

        IStatusEffectType StatusEffectType { get; }

        IStatusEffectCounterUpdate UpdateTiming { get; }

        IStatusEffectInstance StatusEffectInstance { get; }

        void StartEventStatusEffect(IHero hero);

        float EffectValue { get; set; }

        IHeroAction SkillActionAsset { get; }

        IStandardActionAsset StandardAction { get; }

        int MaxSkillCounters { get; }

        //IHero StatusEffectCasterHero { get; set; }
        
        //IHero StatusEffectTargetHero { get; set; }
        
        IHeroStatusEffect HeroStatusEffectReference { get; set; }

        void RemoveStatusEffectOnDeath(IHero hero, IHeroStatusEffect statusEffect);
        
        //TEST
        List<IStandardActionAsset> StandardActions { get; }

        List<ScriptableObject> StandardActionsObjects { get; }




    }
}