using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "CheckFightingSpirit", menuName = "SO's/BasicConditions/CheckFightingSpirit")]
    
    public class CheckFightingSpiritBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private int fightingSpiritLimit;
        
        [SerializeField] private ScriptableObject actionHero;
        private IActionTargets ActionHero => actionHero as IActionTargets;

        protected override int CheckBasicCondition(IHero thisHero)
        {
            var hero = ActionHero.GetHeroTarget(thisHero);
            
            var fightingSpirit = hero.HeroLogic.OtherAttributes.FightingSpirit;
            return fightingSpirit >= fightingSpiritLimit ? 1 : 0;
           

        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var hero = ActionHero.GetHeroTarget(thisHero,targetHero);
            
            var fightingSpirit = hero.HeroLogic.OtherAttributes.FightingSpirit;
            return fightingSpirit >= fightingSpiritLimit ? 1 : 0;
        }
   



    }
}
