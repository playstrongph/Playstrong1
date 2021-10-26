using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.BasicActionScripts
{
    [CreateAssetMenu(fileName = "ResetSkillCooldownToMax", menuName = "SO's/BasicActions/ResetSkillCooldownToMax")]
    
    public class ResetSkillCooldownToMaxBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject heroSkillAssetReference;
        private IHeroSkillAsset HeroSkillAssetReference => heroSkillAssetReference as IHeroSkillAsset;

        private ISkill _skillToReset;

        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           var heroSkillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
           
           var baseCooldown = HeroSkillAssetReference.BaseCooldown;
          

           //Find Skill To Reset to Max Cooldown
           foreach (var heroSkillObject in heroSkillObjects)
           {
               var skill = heroSkillObject.GetComponent<ISkill>();
               if (skill.SkillName == HeroSkillAssetReference.SkillName)
                   _skillToReset = skill;
           }
           
           //var baseCooldown = _skillToReset.SkillLogic.SkillAttributes.BaseCooldown;
           
           logicTree.AddCurrent(_skillToReset.SkillLogic.UpdateSkillCooldown.SetSkillCdToValue(baseCooldown));

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
