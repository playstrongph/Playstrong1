using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Visual
{
    public interface ILoadStatusEffectPreview
    {
        void LoadVisualValues(IStatusEffectAsset statusEffectAsset);
    }
}