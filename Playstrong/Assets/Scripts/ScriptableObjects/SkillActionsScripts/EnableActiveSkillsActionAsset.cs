using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "EnableActiveSkills", menuName = "SO's/SkillActions/EnableActiveSkills")]
    
    public class EnableActiveSkillsActionAsset : SkillActionAsset
    {

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           EnableActiveSkills(targetHero);
            
           logicTree.EndSequence();
           yield return null;

        }

        private void EnableActiveSkills(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.EnableActiveSkill(skill));

            }
        }
        
        
        
        










    }
}
