using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.BasicActionScripts
{
    [CreateAssetMenu(fileName = "RefreshAllSkillCooldownsToReady", menuName = "SO's/BasicActions/RefreshAllSkillCooldownsToReady")]
    
    public class RefreshAllSkillCooldownsToReadyBasicActionAsset : BasicActionAsset
    {
        public override IEnumerator TargetAction(IHero targetHero)
        {

           Debug.Log("Refresh Skill Cooldown targetHero: " +targetHero.HeroName);
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           
           Debug.Log("RefreshSkillCooldownToReady heroSkillObjects Count: " +heroSkillObjects.Count);
           
           var skillReadyValue = 0;
          
            
           //Find Skill To Reset to Max Cooldown
           foreach (var heroSkillObject in heroSkillObjects)
           {
               var skill = heroSkillObject.GetComponent<ISkill>();
               logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(skillReadyValue));
               logicTree.AddCurrent(SetSkillReady(targetHero,skill));
               Debug.Log("SetSkillReady: " +skill.SkillName +" cooldown: " +skill.SkillLogic.SkillAttributes.Cooldown);
               
           }

           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
           
            Debug.Log("RefreshSkillCooldownToReady:" +targetHero.HeroName); 
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           
            var skillReadyValue = 0;
          

            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(skillReadyValue));
                logicTree.AddCurrent(SetSkillReady(targetHero,skill));
                Debug.Log("SetSkillReady: " +skill.SkillName +" cooldown: " +skill.SkillLogic.SkillAttributes.Cooldown);
               
            }
            
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator SetSkillReady(IHero targetHero,ISkill skill)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //_skillToRefresh.SkillLogic.UpdateSkillReadiness.SetSkillReady();
            skill.SkillLogic.SkillAttributes.SkillCooldownType.UpdateSkillReadinessStatus(skill);
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           //No Undo Target Action
           
           logicTree.EndSequence();
            yield return null;

        }
        
        

    }
}
