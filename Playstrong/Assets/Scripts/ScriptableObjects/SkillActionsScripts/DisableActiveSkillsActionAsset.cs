using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DisableActiveSkills", menuName = "SO's/SkillActions/DisableActiveSkills")]
    
    public class DisableActiveSkillsActionAsset : SkillActionAsset
    {

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           DisableActiveSkills(targetHero);
            
           logicTree.EndSequence();
           yield return null;

        }

        private void DisableActiveSkills(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.DisableActiveSkill(skill));

            }
        }
        
        
        
        










    }
}
