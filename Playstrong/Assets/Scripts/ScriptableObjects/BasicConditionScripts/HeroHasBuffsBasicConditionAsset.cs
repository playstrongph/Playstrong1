using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "HeroHasBuffs", menuName = "SO's/BasicConditions/HeroHasBuffs")]
    
    public class HeroHasBuffsBasicConditionAsset : BasicConditionAsset
    {
        protected override int CheckBasicCondition(IHero targetHero)
        {
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            
            
            Debug.Log("1 Hero Has Buffs TargetHero: " +targetHero.HeroName +" All BuffsCount: " +allBuffs.Count );

            return allBuffs.Count > 0 ? 1 : 0;
        }

        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            
          
            
            Debug.Log("2 HeroHasBuffs TargetHero: " +targetHero.HeroName +" All BuffsCount: " +allBuffs.Count );
            
            var thisHeroAllBuffs = thisHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            Debug.Log("2 HeroHasBuffs thisHero: " +thisHero.HeroName +" All BuffsCount: " +thisHeroAllBuffs.Count );


            return allBuffs.Count > 0 ? 1 : 0;
        }
    }
}
