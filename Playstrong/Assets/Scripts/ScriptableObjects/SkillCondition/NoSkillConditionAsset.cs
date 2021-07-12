using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
    [CreateAssetMenu(fileName = "NoSkillConditionAsset", menuName = "SO's/SkillConditions/NoSkillConditionAsset")]
    
    public class NoSkillConditionAsset : SkillConditionAsset
    {
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
            return true;
        }


    }
}
