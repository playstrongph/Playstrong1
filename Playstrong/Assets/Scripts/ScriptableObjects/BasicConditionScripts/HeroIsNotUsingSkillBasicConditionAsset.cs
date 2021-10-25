using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "HeroIsNotUsingSkill", menuName = "SO's/BasicConditions/HeroIsNotUsingSkill")]
    
    public class HeroIsNotUsingSkillBasicConditionAsset : BasicConditionAsset
    {

        /*[Header("Skill Ready Reference")]
        [SerializeField] private ScriptableObject skillReadyAsset;
        private ISkillReadiness SkillReadyAsset => skillReadyAsset as ISkillReadiness;*/


        protected override int CheckBasicCondition(IHero thisHero)
        {
            var usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.NotUsingSkill(SkillReference);
            
            Debug.Log("Skill Use Status Value Single Argument: " +usingSkill);
            
            return usingSkill;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.NotUsingSkill(SkillReference);
            
            Debug.Log("Skill Use Status Value 2 Arguments: " +usingSkill);
            
            return usingSkill;
        }
   



    }
}
