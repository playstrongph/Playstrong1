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
    [CreateAssetMenu(fileName = "HeroBelongsToSpecificFaction", menuName = "SO's/BasicConditions/HeroBelongsToSpecificFaction")]
    
    public class HeroBelongsToSpecificFactionBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private ScriptableObject faction;
        private IFactionEnumAsset Faction  => faction as IFactionEnumAsset;

       

        protected override int CheckBasicCondition(IHero targetHero)
        {
            var heroFaction = targetHero.HeroLogic.OtherAttributes.Faction;

            return heroFaction == Faction ? 1 : 0;
        }

       

        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var heroFaction = targetHero.HeroLogic.OtherAttributes.Faction;

            return heroFaction == Faction ? 1 : 0;
        }
        
       
   



    }
}
