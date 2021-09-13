using UnityEngine;

namespace ScriptableObjects.SkillStatusEffectType
{
    public class SkillStatusEffectType : ScriptableObject
    {

        public virtual void AddToSkillStatusEffectsList()
        {
            //Overriding method selects 1 from below:
            //AddToSkillBuffsList();
            //AddToSkillDebuffsList();
        }
        
        public virtual void RemoveFromSkillStatusEffectsList()
        {
            //Overriding method selects 1 from below:
            //RemoveFromSkillBuffsList();
            //RemoveFromSkillDebuffsList();
        }

        private void AddToSkillBuffsList()
        {
            
            //TODO: Create HeroSkillStatusEffects component (gameObject)
            //TODO: Create HeroSkillStatusEffect component (prefab)
            //Used by SkillBuffTypeAsset 
        }

        private void RemoveFromSkillBuffsList()
        {
            //TODO: Create HeroSkillStatusEffects component (gameObject)
            //TODO: Create HeroSkillStatusEffect component (prefab)
            //Used by SkillBuffTypeAsset 
        }
        
        private void AddToSkillDebuffsList()
        {
            //TODO: Create HeroSkillStatusEffects component (gameObject)
            //TODO: Create HeroSkillStatusEffect component (prefab)
            //Used by SkillDebuffTypeAsset 
        }

        private void RemoveFromSkillDebuffsList()
        {
            //TODO: Create HeroSkillStatusEffects component (gameObject)
            //TODO: Create HeroSkillStatusEffect component (prefab)
            //Used by SkillDebuffTypeAsset 
        }
        
        

    }
}
