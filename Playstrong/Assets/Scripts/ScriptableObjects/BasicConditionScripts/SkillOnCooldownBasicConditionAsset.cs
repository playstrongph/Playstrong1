using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    /// <summary>
    /// Checks if skill's cooldown is greater than zero.  Note that the condition does not
    /// check if skill is ready or enabled
    /// </summary>
    [CreateAssetMenu(fileName = "SkillOnCooldown", menuName = "SO's/BasicConditions/SkillOnCooldown")]
    public class SkillOnCooldownBasicConditionAsset : BasicConditionAsset
    {

        [SerializeField] private ScriptableObject heroSkillAsset;
        private IHeroSkillAsset HeroSkillAsset => heroSkillAsset as IHeroSkillAsset;

        private ISkill _skill;
        private int _skillCooldown;

        protected override int CheckBasicCondition(IHero thisHero)
        {
            var heroSkillObjects = thisHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skill = skill;
            }
            
            if (_skill != null)
            {
                _skillCooldown = _skill.SkillLogic.SkillAttributes.Cooldown;
            }
            
            return _skillCooldown > 0 ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var heroSkillObjects = thisHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skill = skill;
            }
            
            if (_skill != null)
            {
                _skillCooldown = _skill.SkillLogic.SkillAttributes.Cooldown;
            }
            
            return _skillCooldown > 0 ? 1 : 0;
        }
   



    }
}
