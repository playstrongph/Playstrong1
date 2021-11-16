using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    
    [CreateAssetMenu(fileName = "SkillCountersCountCalculatedFactor", menuName = "SO's/Scriptable Enums/CalculatedFactorValue/SkillCountersCountCalculatedFactor")]
    public class SkillCountersCountCalculatedFactorAsset : CalculatedFactorValueAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        private ISkill _skillCountersReference;
        
        
        public override float GetCalculatedValue()
        {
            var skillCountersCount = 0;
            
            GetSkillReference();

            if (CalculationHeroBasis != null)
                skillCountersCount = _skillCountersReference.SkillLogic.SkillOtherAttributes.SkillCounters;

            return skillCountersCount;
        }

        private void GetSkillReference()
        {
            var heroSkillObjects = CalculationHeroBasis.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAssetReference.SkillName)
                    _skillCountersReference = skill;
            }
        }

    }
}
