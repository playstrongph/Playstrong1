using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "SkillDebuffType", menuName = "SO's/Status Effects/Type/SkillDebuffType")]
    public class SkillDebuffTypeAsset : StatusEffectTypeAsset
    {

        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroSkillDebuffEffects.AddToList(heroStatusEffect);
            
        }

        public override void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            heroStatusEffects.HeroSkillDebuffEffects.RemoveFromList(heroStatusEffect);
        }

    }
}
