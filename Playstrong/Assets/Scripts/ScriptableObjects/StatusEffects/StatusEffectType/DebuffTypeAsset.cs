using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "DebuffType", menuName = "SO's/Status Effects/Type/DebuffType")]
    public class DebuffTypeAsset : StatusEffectTypeAsset
    {
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroDebuffEffects.AddToList(heroStatusEffect);
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroDebuffEffects.RemoveFromList(heroStatusEffect);
        }

    }
}
