using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAllSkillCd", menuName = "SO's/SkillActions/IncreaseAllSkillCd")]
    
    public class IncreaseAllSkillCdActionAsset : SkillActionAsset
    {
        [SerializeField] private int skillCdIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            skillCdIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillsObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;

            foreach (var heroSkillObject in heroSkillsObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                var skillCd = skill.SkillLogic.SkillAttributes.Cooldown;
                var newSkillCd = skillCd + skillCdIncrease;
                
                skill.SkillLogic.ChangeSkillCooldown.SetCooldownValue(newSkillCd);
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
