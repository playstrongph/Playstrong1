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
    [CreateAssetMenu(fileName = "SetSkillToNotReady", menuName = "SO's/BasicActions/SetSkillToNotReady")]
    public class SetSkillToNotReadyBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        private ISkill _skillToSetNotReady;

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
                   _skillToSetNotReady = skill;
           }
           
           
           //TEST - null check not required in final version
           if (_skillToSetNotReady != null)
           {
               logicTree.AddCurrent(SetSkillNotReady(targetHero));
               Debug.Log("SetSkillReady: " +_skillToSetNotReady.SkillName);
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
                    _skillToSetNotReady = skill;
            }
           
           
            //TEST - null check not required in final version
            if (_skillToSetNotReady != null)
            {
                logicTree.AddCurrent(SetSkillNotReady(targetHero));
                Debug.Log("SetSkillReady: " +_skillToSetNotReady.SkillName);
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
        private IEnumerator SetSkillNotReady(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            _skillToSetNotReady.SkillLogic.SkillAttributes.SkillEnabledStatus.SetSkillNotReady(_skillToSetNotReady);
            
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
