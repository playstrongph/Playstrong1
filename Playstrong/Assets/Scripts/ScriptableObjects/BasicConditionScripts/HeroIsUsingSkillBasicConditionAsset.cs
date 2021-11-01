using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "HeroIsUsingSkill", menuName = "SO's/BasicConditions/HeroIsUsingSkill")]
    
    public class HeroIsUsingSkillBasicConditionAsset : BasicConditionAsset
    {

        /*[Header("Skill Ready Reference")]
        [SerializeField] private ScriptableObject skillReadyAsset;
        private ISkillReadiness SkillReadyAsset => skillReadyAsset as ISkillReadiness;*/


        protected override int CheckBasicCondition(IHero thisHero)
        {
            var usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.UsingSkill(SkillReference);
            
            Debug.Log("Using Skill 1 Reference: " +SkillReference.SkillName);
            
            return usingSkill;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.UsingSkill(SkillReference);
            
            Debug.Log("Using Skill 2 Reference: " +SkillReference.SkillName);
            
            return usingSkill;
        }
   



    }
}
