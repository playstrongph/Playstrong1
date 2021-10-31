using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "SkillCountersWithinLimit", menuName = "SO's/BasicConditions/SkillCountersWithinLimit")]
    
    public class SkillCountersWithinLimitBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private int skillCountersLimit;
        
        [SerializeField] private ScriptableObject heroSkillAsset;
        private IHeroSkillAsset HeroSkillAsset => heroSkillAsset as IHeroSkillAsset;

        private ISkill _skill;
        private int _skillCounters;

        protected override int CheckBasicCondition(IHero targetHero)
        {
            //var hero = ActionHero.GetHeroTarget(thisHero);

            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skill = skill;
            }
            
            if (_skill != null)
            {
                _skillCounters = _skill.SkillLogic.SkillOtherAttributes.SkillCounters;
                
            }


            return _skillCounters < skillCountersLimit ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skill = skill;
            }
            
            if (_skill != null)
            {
                _skillCounters = _skill.SkillLogic.SkillOtherAttributes.SkillCounters;
            }


            return _skillCounters < skillCountersLimit ? 1 : 0;
        }
   



    }
}
