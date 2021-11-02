using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroStatusEffectImmunity
    {
        int ImmunityPercentage { get; }
        IStatusEffectAsset StatusEffectAsset { get; }
    }
}