using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "SkillBuffType", menuName = "SO's/Status Effects/Type/SkillBuffType")]
    public class SkillBuffTypeAsset : StatusEffectTypeAsset
    {

        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroSkillBuffEffects.AddToList(heroStatusEffect);
            
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroSkillBuffEffects.RemoveFromList(heroStatusEffect);
        }

    }
}
