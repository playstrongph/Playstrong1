using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseSkillCounters", menuName = "SO's/BasicActions/D/DecreaseSkillCounters")]
    
    public class DecreaseSkillCountersBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int skillCounters;

        [SerializeField] private ScriptableObject heroSkillAsset;
        private IHeroSkillAsset HeroSkillAsset => heroSkillAsset as IHeroSkillAsset;

        private ISkill _skillToIncreaseCounters;
        

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            
            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                if (skill.SkillName == HeroSkillAsset.SkillName)
                    _skillToIncreaseCounters = skill;
            }
            
            if (_skillToIncreaseCounters != null)
            {
                _skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters -= skillCounters;
                _skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters = 
                    Mathf.Max(_skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters, 0);
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
                    _skillToIncreaseCounters = skill;
            }
            
            if (_skillToIncreaseCounters != null)
            {
                _skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters -= skillCounters;
                _skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters = 
                    Mathf.Max(_skillToIncreaseCounters.SkillLogic.SkillOtherAttributes.SkillCounters, 0);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
       

      










    }
}
