using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "EnablePassiveSkills", menuName = "SO's/SkillActions/EnablePassiveSkills")]
    
    public class EnablePassiveSkillsActionAsset : SkillActionAsset
    {
        
        private ISkill _targetSkill;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           EnablePassiveSkills(targetHero);
           
           logicTree.EndSequence();
           yield return null;

        }

        private void EnablePassiveSkills(IHero targetHero)
        {
            Debug.Log("EnablePassive Skill Action");
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                _targetSkill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(_targetSkill.SkillLogic.SkillAttributes.SkillType.EnablePassiveSkill(_targetSkill));
                
                //_targetSkill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(_targetSkill);
                
            }
        }
        
        
        
        
        
        










    }
}
