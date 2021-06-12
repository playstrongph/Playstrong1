using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class AddBuffSkillActionAsset : SkillActionAsset, IAddBuffSkillActionAsset
    {

        public override void Target()
        {
            
        }
        
        

        private void AddBuff(IHero hero)
        {
            var buffPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var heroBuffPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;

            var buffObject = Instantiate(buffPrefab, heroBuffPanel);
            var buff = buffObject.GetComponent<IHeroStatusEffect>();
            
            //Load StatusEffect
            //Apply StatusEffect effect
        }

    }
}
