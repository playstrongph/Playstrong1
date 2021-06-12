using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffect
    {

        void ApplyStatusEffect();

        string Name { get; }

        string Description { get; }

        Sprite Icon { get; }

        IStatusEffectType StatusEffectType { get; }

    }
}