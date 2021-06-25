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
            heroStatusEffects.HeroDebuffEffects.HeroDebuffs.Add(debuffEffect);
            
            //Add to Object List, Inspector Display Purposes only
            heroStatusEffects.HeroDebuffEffects.HeroDebuffObjects.Add(debuffEffect as Object);
        }
        
        private void RemoveFromHeroDebuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect debuffEffect)
        {
            Debug.Log("Remove from hero buffs list");
            heroStatusEffects.HeroDebuffEffects.HeroDebuffs.Remove(debuffEffect);
            
            //Add to Object List, Inspector Display Purposes only
            heroStatusEffects.HeroDebuffEffects.HeroDebuffObjects.Remove(debuffEffect as Object);
        }
        

    }
}
