using System;
using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptableObjects.SkillCondition
{
    [CreateAssetMenu(fileName = "ChanceSkillConditionAsset", menuName = "SO's/SkillConditions/ChanceSkillConditionAsset")]
    
    public class ChanceSkillConditionAsset : SkillConditionAsset, IChanceSkillConditionAsset
    {

        [SerializeField] private int _skillChance;
        private int SkillChance => _skillChance;

        public  override void UseSkillAction(IHero thisHero, IHero targetHero)
        {
            if(SkillCondition(thisHero))
                base.UseSkillAction(thisHero,targetHero);
        }

         
        private bool SkillCondition(IHero thisHero)
        {
            var chanceValue = Random.Range(0, 100);
            var skillChanceBonus = thisHero.HeroLogic.OtherAttributes.SkillChanceBonus;
            var finalSkillChance = SkillChance + skillChanceBonus;
            
            
            finalSkillChance = Mathf.Clamp(finalSkillChance, 0, 100);
            var chanceSuccess = chanceValue <= finalSkillChance;
             
            return chanceSuccess;
        }


    }
}
