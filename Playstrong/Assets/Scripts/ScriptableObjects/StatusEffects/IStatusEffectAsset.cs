using Interfaces;
using Logic;
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

        int MaxSkillCounters { get; }

        IHero CasterHero { get; set; }
        
        IHeroStatusEffect HeroStatusEffectReference { get; set; }

        void RemoveStatusEffect(IHero hero);




    }
}