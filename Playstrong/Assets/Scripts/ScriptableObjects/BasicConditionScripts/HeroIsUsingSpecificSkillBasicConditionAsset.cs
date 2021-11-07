using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "HeroIsUsingSpecificSkill", menuName = "SO's/BasicConditions/HeroIsUsingSpecificSkill")]
    
    public class HeroIsUsingSpecificSkillBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private ScriptableObject usingThisSkill;
        private IHeroSkillAsset UsingThisSkill => usingThisSkill as IHeroSkillAsset;

        private ISkill _specificSkill;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            var allSkills = targetHero.HeroLogic.GetAllHeroSkills.HeroSkills(targetHero);

            foreach (var skill in allSkills)
            {
                if (skill.SkillName == UsingThisSkill.SkillName)
                {
                    _specificSkill = skill;
                }
            }

            //TEST
            var usingSkill = 0;

            if (_specificSkill != null)
            {
                usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.UsingSkill(_specificSkill);    
                Debug.Log("Using Skill 2 Reference: " +_specificSkill.SkillName +" return value: " +usingSkill);
            }

            Debug.Log("Skill Reference: " +SkillReference+" Using specific skill return value: " +usingSkill);
            
            return usingSkill;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var allSkills = targetHero.HeroLogic.GetAllHeroSkills.HeroSkills(targetHero);

            foreach (var skill in allSkills)
            {
                if (skill.SkillName == UsingThisSkill.SkillName)
                {
                    _specificSkill = skill;
                }
            }
            
            //TEST
            var usingSkill = 0;

            if (_specificSkill != null)
            {
                usingSkill = SkillReference.SkillLogic.SkillAttributes.SkillUseStatus.UsingSkill(_specificSkill);    
                Debug.Log("Using Skill 2 Reference: " +_specificSkill.SkillName +" return value: " +usingSkill);
            }

            Debug.Log("Skill Reference: " +SkillReference+" Using specific skill return value: " +usingSkill);
            
            return usingSkill;
        }
   



    }
}
