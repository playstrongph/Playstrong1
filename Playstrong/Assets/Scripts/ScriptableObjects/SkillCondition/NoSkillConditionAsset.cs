using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
    [CreateAssetMenu(fileName = "NoSkillConditionAsset", menuName = "SO's/SkillConditions/NoSkillConditionAsset")]
    
    public class NoSkillConditionAsset : SkillConditionAsset
    {
        public  override void UseSkillAction(IHero thisHero, IHero targetHero)
        {
            base.UseSkillAction(thisHero,targetHero);
            
           
        }

        


    }
}
