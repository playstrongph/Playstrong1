using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "SkillBuffType", menuName = "SO's/Status Effects/Type/SkillBuffType")]
    public class SkillBuffTypeAsset : StatusEffectTypeAsset
    {

        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            //AddToHeroBuffsList(heroStatusEffects, heroStatusEffect);
            //TODO: AddToHeroSkillBuffsList
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            //RemoveFromHeroBuffsList(heroStatusEffects, heroStatusEffect);
            //TODO: RemoveFromHeroSkillBuffsList
        }

    }
}
