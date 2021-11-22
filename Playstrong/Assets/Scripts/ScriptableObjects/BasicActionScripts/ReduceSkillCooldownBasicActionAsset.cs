using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.BasicActionScripts
{
    [CreateAssetMenu(fileName = "ReduceSkillCooldown", menuName = "SO's/BasicActions/R/ReduceSkillCooldown")]
    
    public class ReduceSkillCooldownBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        [SerializeField] private int flatReduceCounters;

        [SerializeField] private ScriptableObject calculatedReduceCounters;
        private ICalculatedFactorValueAsset CalculatedReduceCounters => calculatedReduceCounters as ICalculatedFactorValueAsset;
        

        private ISkill _skillToRefresh;
       

        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           var newSkillCooldownValue = flatReduceCounters + (int)CalculatedReduceCounters.GetCalculatedValue();

           //Find Skill To Reduce CD
           foreach (var heroSkillObject in heroSkillObjects)
           {
               var skill = heroSkillObject.GetComponent<ISkill>();
               
               Debug.Log("skill name: " +skill.SkillName +" HeroSkillAsset Name: " +HeroSkillAssetReference.SkillName );
               if (skill.SkillName == HeroSkillAssetReference.SkillName)
                   _skillToRefresh = skill;
           }

           //TEST - null check not required in final version
           if (_skillToRefresh != null)
               logicTree.AddCurrent(_skillToRefresh.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(newSkillCooldownValue));
           

           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            var newSkillCooldownValue = flatReduceCounters + (int)CalculatedReduceCounters.GetCalculatedValue();

            //Find Skill To Reduce CD
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
               
                Debug.Log("skill name: " +skill.SkillName +" HeroSkillAsset Name: " +HeroSkillAssetReference.SkillName );
                if (skill.SkillName == HeroSkillAssetReference.SkillName)
                    _skillToRefresh = skill;
            }

            //TEST - null check not required in final version
            if (_skillToRefresh != null)
                logicTree.AddCurrent(_skillToRefresh.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(newSkillCooldownValue));
           

            logicTree.EndSequence();
            yield return null;

        }

        
       
        

    }
}
