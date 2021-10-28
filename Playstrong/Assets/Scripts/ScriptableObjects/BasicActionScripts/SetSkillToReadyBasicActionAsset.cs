using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.BasicActionScripts
{
    
    /// <summary>
    /// Special implementation of RefreshSkillCooldownToReady - bypasses cooldown and cooldown type checks
    /// Used by special skills such as Ravi's Devil Drive.  Normal implementation should be to use
    /// RefreshSkillCooldownToReady basic action asset
    /// </summary>
    [CreateAssetMenu(fileName = "SetSkillToReady", menuName = "SO's/BasicActions/SetSkillToReady")]
    public class SetSkillToReadyBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        private ISkill _skillToSetReady;

        public override IEnumerator TargetAction(IHero targetHero)
        {
           
           Debug.Log("SetSkillReady targetHero: " +targetHero.HeroName);
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           
           //Debug.Log("SetSkillReady heroSkillObjects Count: " +heroSkillObjects.Count);

           //Find Skill To Reset to Max Cooldown
           foreach (var heroSkillObject in heroSkillObjects)
           {
               var skill = heroSkillObject.GetComponent<ISkill>();
               //Debug.Log("skill name: " +skill.SkillName +" HeroSkillAsset Name: " +HeroSkillAssetReference.SkillName );
               if (skill.SkillName == HeroSkillAssetReference.SkillName)
                   _skillToSetReady = skill;
           }
           
           
           //TEST - null check not required in final version
           if (_skillToSetReady != null)
           {
               logicTree.AddCurrent(SetSkillReady(targetHero));
               Debug.Log("SetSkillReady: " +_skillToSetReady.SkillName);
           }

           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
           
            Debug.Log("SetSkillReady targetHero: " +targetHero.HeroName);
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           
            //Debug.Log("SetSkillReady heroSkillObjects Count: " +heroSkillObjects.Count);

            //Find Skill To Reset to Max Cooldown
            foreach (var heroSkillObject in heroSkillObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                //Debug.Log("skill name: " +skill.SkillName +" HeroSkillAsset Name: " +HeroSkillAssetReference.SkillName );
                if (skill.SkillName == HeroSkillAssetReference.SkillName)
                    _skillToSetReady = skill;
            }
           
           
            //TEST - null check not required in final version
            if (_skillToSetReady != null)
            {
                logicTree.AddCurrent(SetSkillReady(targetHero));
                Debug.Log("SetSkillReady: " +_skillToSetReady.SkillName);
            }

            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Bypasses SkillCooldown type and proceeds directly to Skill Enabled Status
        /// This action is only used by special skills of NoSkillCooldownType
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator SetSkillReady(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            _skillToSetReady.SkillLogic.SkillAttributes.SkillEnabledStatus.SetSkillReady(_skillToSetReady);
            
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
