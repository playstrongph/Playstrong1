using Logic;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    public interface IStatusEffectType
    {

        void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);

        void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);
    }
}