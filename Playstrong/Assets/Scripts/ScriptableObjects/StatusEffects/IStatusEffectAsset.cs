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

        void StartTurnStatusEffect(IHero hero);

        void EndTurnStatusEffect(IHero hero);

        string Name { get; }

        string Description { get; }

        Sprite Icon { get; }

        IStatusEffectType StatusEffectType { get; }

        IStatusEffectCounterUpdate UpdateTiming { get; }

        IStatusEffectInstance StatusEffectInstance { get; }


    }
}