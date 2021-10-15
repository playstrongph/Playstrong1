using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "ResetSkillCooldownToMax", menuName = "SO's/BasicActions/ResetSkillCooldownToMax")]
    
    public class ResetSkillCooldownToMaxBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject _heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => _heroSkillAssetReference as IHeroSkillAsset;

        private ISkill skillToReset;

        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           var baseCooldown = HeroSkillAssetReference.BaseCooldown;
           
           Debug.Log("Skill To Reset Hero Reference: " +targetHero.HeroName);

           //Find Skill To Reset to Max Cooldown
           foreach (var heroSkillObject in heroSkillObjects)
           {
               var skill = heroSkillObject.GetComponent<ISkill>();
               Debug.Log("Skill Name: " +skill.SkillName +" Skill Reference Name: " +HeroSkillAssetReference.SkillName);

               if (skill.SkillName == HeroSkillAssetReference.SkillName)
                   skillToReset = skill;
           }

           if (skillToReset != null)
           {
               Debug.Log("Skill To Reset " +skillToReset.SkillName);
               logicTree.AddCurrent(skillToReset.SkillLogic.ChangeSkillCooldown.SetSkillCdToValue(baseCooldown));
           }

           

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
