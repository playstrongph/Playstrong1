using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "BuffType", menuName = "SO's/Status Effects/Type/BuffType")]
    public class BuffTypeAsset : StatusEffectTypeAsset
    {
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroBuffEffects.AddToList(heroStatusEffect);
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroBuffEffects.RemoveFromList(heroStatusEffect);
        }
    }
}
