using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.BasicActionScripts
{
    [CreateAssetMenu(fileName = "RefreshSkillCooldownToReady", menuName = "SO's/BasicActions/RefreshSkillCooldownToReady")]
    
    public class RefreshSkillCooldownToReadyBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        private ISkill _skillToRefresh;

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
               
               Debug.Log("skill name: " +skill.SkillName +" HeroSkillAsset Name: " +HeroSkillAssetReference.SkillName );
               if (skill.SkillName == HeroSkillAssetReference.SkillName)
                   _skillToRefresh = skill;
           }
           
           
           //TEST - null check not required in final version
           if (_skillToRefresh != null)
           {
               logicTree.AddCurrent(_skillToRefresh.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(skillReadyValue));
               logicTree.AddCurrent(SetSkillReady(targetHero));
               Debug.Log("SetSkillReady: " +_skillToRefresh.SkillName +" cooldown: " +_skillToRefresh.SkillLogic.SkillAttributes.Cooldown);
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
                if (skill.SkillName == HeroSkillAssetReference.SkillName)
                    _skillToRefresh = skill;
            }
           
           
            //TEST - null check not required in final version
            if (_skillToRefresh != null)
            {
                logicTree.AddCurrent(_skillToRefresh.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(skillReadyValue));
                logicTree.AddCurrent(SetSkillReady(targetHero));
            }

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator SetSkillReady(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //_skillToRefresh.SkillLogic.UpdateSkillReadiness.SetSkillReady();
            _skillToRefresh.SkillLogic.SkillAttributes.SkillEnabledStatus.SetSkillReady(_skillToRefresh);
            
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
