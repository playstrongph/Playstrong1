using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "DebuffType", menuName = "SO's/Status Effects/Type/DebuffType")]
    public class DebuffTypeAsset : ScriptableObject, IStatusEffectType
    {
        public void  AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            AddToHeroDebuffsList(heroStatusEffects, heroStatusEffect);
        }

        public void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            RemoveFromHeroDebuffsList(heroStatusEffects, heroStatusEffect);
        }

        private void AddToHeroDebuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect debuffEffect)
        {
            heroStatusEffects.HeroDebuffEffects.AddToList(debuffEffect);
        }
        
        private void RemoveFromHeroDebuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect debuffEffect)
        {
            heroStatusEffects.HeroDebuffEffects.RemoveFromList(debuffEffect);
        }
        

    }
}
