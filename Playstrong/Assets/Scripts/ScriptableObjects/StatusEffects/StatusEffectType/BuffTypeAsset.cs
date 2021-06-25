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
       
            heroStatusEffects.HeroBuffEffects.HeroBuffs.Add(buffEffect);
            
            //Add to Object List, Inspector Display Purposes only
            heroStatusEffects.HeroBuffEffects.HeroBuffObjects.Add(buffEffect as Object);
        }
        
        private void RemoveFromHeroBuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect buffEffect)
        {
            
            heroStatusEffects.HeroBuffEffects.HeroBuffs.Remove(buffEffect);
            
            //Add to Object List, Inspector Display Purposes only
            heroStatusEffects.HeroBuffEffects.HeroBuffObjects.Remove(buffEffect as Object);
        }

    }
}
