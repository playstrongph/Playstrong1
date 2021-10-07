using Interfaces;
using ScriptableObjects.StatusEffects;

namespace Visual
{
    public interface ILoadStatusEffectValues
    {
        void LoadValues(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero);
    }
}