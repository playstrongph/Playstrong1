using ScriptableObjects.StatusEffects;

namespace Visual
{
    public interface ILoadStatusEffectValues
    {
        void LoadValues(IStatusEffectAsset statusEffect, int counters);
    }
}