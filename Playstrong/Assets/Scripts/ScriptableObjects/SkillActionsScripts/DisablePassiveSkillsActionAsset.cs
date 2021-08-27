using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DisablePassiveSkills", menuName = "SO's/SkillActions/DisablePassiveSkills")]
    
    public class DisablePassiveSkillsActionAsset : SkillActionAsset
    {
        private ISkill _targetSkill;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           DisablePassiveSkills(targetHero);
            
           logicTree.EndSequence();
           yield return null;

        }

        private void DisablePassiveSkills(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                _targetSkill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(_targetSkill.SkillLogic.SkillAttributes.SkillType.DisablePassiveSkill(_targetSkill));

            }
            
        }

     














    }
}
