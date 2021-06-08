using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine.UI;

namespace ScriptableObjects.StatusEffects
{
    public interface IStatusEffect
    {

        void ApplyStatusEffect();

        string Name { get; }

        string Description { get; }

        Image Icon { get; }

        IStatusEffectType StatusEffectType { get; }

    }
}