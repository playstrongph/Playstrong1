using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
    [CreateAssetMenu(fileName = "ChanceSkillConditionAsset", menuName = "SO's/SkillConditions/ChanceSkillConditionAsset")]
    
    public class ChanceSkillConditionAsset : SkillConditionAsset, IChanceSkillConditionAsset
    {

        [SerializeField] private int _skillChance;
        private int SkillChance => _skillChance;

        public  override void Target(IHero thisHero, IHero targetHero)
        {
            if(SkillCondition())
                base.Target(thisHero,targetHero);
        }

        /// <summary>
        /// This is unique for each Skill Condition Asset
        /// </summary>
        /// <returns></returns>
        private bool SkillCondition()
        {
            var chanceValue = Random.Range(0, 100);

            var chanceSuccess = chanceValue <= SkillChance;
            
            return chanceSuccess;
        }


    }
}
