using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseSkillCounters", menuName = "SO's/BasicActions/D/DecreaseSkillCounters")]
    
    public class DecreaseSkillCountersBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int skillCounters;

        [SerializeField] private ScriptableObject calculatedValue;
        private ICalculatedFactorValueAsset CalculatedValue => calculatedValue as ICalculatedFactorValueAsset;
        

        [SerializeField] private ScriptableObject heroSkillAsset;
        private IHeroSkillAsset HeroSkillAsset => heroSkillAsset as IHeroSkillAsset;

        private ISkill _skillToDecreaseCounters;
        

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skillToDecreaseCounters = skill;
            }
            
            if (_skillToDecreaseCounters != null)
            {
                var totalSkillCounters = skillCounters + (int)CalculatedValue.GetCalculatedValue(); 
                    
                _skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters -= totalSkillCounters;
                _skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters = 
                    Mathf.Max(_skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters, 0);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skillToDecreaseCounters = skill;
            }
            
            if (_skillToDecreaseCounters != null)
            {
                var totalSkillCounters = skillCounters + (int)CalculatedValue.GetCalculatedValue(); 
                
                _skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters -= totalSkillCounters;
                _skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters = 
                    Mathf.Max(_skillToDecreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters, 0);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
       

      










    }
}
