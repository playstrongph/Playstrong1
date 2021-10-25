using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "ChanceBasicCondition", menuName = "SO's/BasicConditions/ChanceBasicCondition")]
    
    public class ChanceBasicConditionAsset : BasicConditionAsset
    {
        [SerializeField] private int chanceValue;


        protected override int CheckBasicCondition(IHero thisHero)
        {
            
            var heroChance = thisHero.HeroLogic.HeroAttributes.Chance;
            var totalChance = chanceValue + heroChance;
            var randomNumber = Random.Range(1, 101);
            
            Debug.Log("Hero: " +thisHero.HeroName +" Chance: " +thisHero.HeroLogic.HeroAttributes.Chance);

            return randomNumber <= totalChance ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            
            var heroChance = thisHero.HeroLogic.HeroAttributes.Chance;
            var totalChance = chanceValue + heroChance;
            var randomNumber = Random.Range(1, 101);
            
            Debug.Log("2Hero: " +thisHero.HeroName +" 2Chance: " +thisHero.HeroLogic.HeroAttributes.Chance);

            return randomNumber <= totalChance ? 1 : 0;
        }

    }
}
