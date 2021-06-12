using Interfaces;
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
        
        public  override void Target(IHero hero)
        {
            if(ChanceSuccess())
                base.Target(hero);
        }

        private bool ChanceSuccess()
        {
            var chanceValue = Random.Range(0, 100);

            var chanceSuccess = chanceValue <= SkillChance;
            
            return chanceSuccess;
        }


    }
}
