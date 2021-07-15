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
            base.Target(thisHero,targetHero);
            
            Debug.Log("NoSkillConditionAsset Target");
        }

        


    }
}
