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

        private int _chanceValue;

        public  override void Target(IHero thisHero, IHero targetHero)
        {
            if(SkillCondition())
                base.Target(thisHero,targetHero);
            
            Debug.Log("Chance Value: " +_chanceValue);
        }

        /// <summary>
        /// This is unique for each Skill Condition Asset
        /// </summary>
        /// <returns></returns>
        private bool SkillCondition()
        {
            _chanceValue = Random.Range(0, 100);
            var chanceSuccess = _chanceValue <= SkillChance;
            return chanceSuccess;
        }


    }
}
