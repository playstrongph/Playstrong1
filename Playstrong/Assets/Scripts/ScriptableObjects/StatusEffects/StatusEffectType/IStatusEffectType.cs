using Logic;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    public interface IStatusEffectType
    {

        void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);

        void RemoveStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect);
    }
}