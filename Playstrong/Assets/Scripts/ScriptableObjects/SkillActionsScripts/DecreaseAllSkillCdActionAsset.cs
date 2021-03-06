using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseAllSkillCd", menuName = "SO's/SkillActions/DecreaseAllSkillCd")]
    
    public class DecreaseAllSkillCdActionAsset : SkillActionAsset
    {
        [SerializeField] private int skillCdDecrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            skillCdDecrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillsObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;

            foreach (var heroSkillObject in heroSkillsObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                var skillCd = skill.SkillLogic.SkillAttributes.Cooldown;
                var newSkillCd = skillCd - skillCdDecrease;
                
                //skill.SkillLogic.ChangeSkillCooldown.SetCooldownValue(newSkillCd);
                
                //Test
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.SetSkillCdValue(skill.SkillLogic, newSkillCd));
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
