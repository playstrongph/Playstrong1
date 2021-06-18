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

        private void AddToHeroDebuffsList(IHeroStatusEffects heroStatusEffects, IHeroStatusEffect debuffEffect)
        {
            heroStatusEffects.HeroDebuffEffects.HeroDebuffs.Add(debuffEffect);
            
            //Add to Object List, Inspector Display Purposes only
            heroStatusEffects.HeroDebuffEffects.HeroDebuffObjects.Add(debuffEffect as Object);
        }
        

    }
}
