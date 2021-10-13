using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "UniqueEffectType", menuName = "SO's/Status Effects/Type/UniqueEffectType")]
    public class UniqueEffectTypeAsset : StatusEffectTypeAsset
    {
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroUniqueEffects.AddToList(heroStatusEffect);
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroUniqueEffects.RemoveFromList(heroStatusEffect);
        }
    }
}
