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
        
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }
        IStatusEffectType StatusEffectType { get; }
        IStatusEffectCounterUpdate UpdateTiming { get; }
        IStatusEffectInstance StatusEffectInstance { get; }
        int MaxSkillCounters { get; }
        //TEST
        List<IStandardActionAsset> StandardActions { get; }
        List<ScriptableObject> StandardActionsObjects { get; }
        
        
        
        void ApplyStatusEffect(IHero hero);
        void UnapplyStatusEffect(IHero hero);
        void ApplyStackingEffect(IHero hero);
        void UnapplyStackingEffect(IHero hero);
        void RemoveStatusEffectOnDeath(IHero hero, IHeroStatusEffect statusEffect);
        
        
        //CLEANUP
        //IHero StatusEffectCasterHero { get; set; }
        //IHero StatusEffectTargetHero { get; set; }
        //IHeroStatusEffect HeroStatusEffectReference { get; }
        //void StartEventStatusEffect(IHero hero);
        //float EffectValue { get; set; }
        /*IHeroAction SkillActionAsset { get; }
        IStandardActionAsset StandardAction { get; }
        */




    }
}