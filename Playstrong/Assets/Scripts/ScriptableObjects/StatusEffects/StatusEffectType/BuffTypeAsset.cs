using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.StatusEffectType
{
    [CreateAssetMenu(fileName = "BuffType", menuName = "SO's/Status Effects/Type/BuffType")]
    public class BuffTypeAsset : ScriptableObject, IStatusEffectType
    {

        public void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            AddToHeroBuffsList(heroStatusEffects, heroStatusEffect);
        }

        public void RemoveFromStatusEffectList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect heroStatusEffect)
        {
            RemoveFromHeroBuffsList(heroStatusEffects, heroStatusEffect);
        }

        private void AddToHeroBuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect buffEffect)
        {
            heroStatusEffects.HeroBuffEffects.AddToList(buffEffect);
        }
        
        private void RemoveFromHeroBuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect buffEffect)
        {
            heroStatusEffects.HeroBuffEffects.RemoveFromList(buffEffect);
        }

    }
}
