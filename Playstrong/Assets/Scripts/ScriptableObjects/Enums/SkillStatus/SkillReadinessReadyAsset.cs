using Interfaces;
using References;
using ScriptableObjects.Scriptable_Enums.SkillReadiness;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillReady", menuName = "SO's/Scriptable Enums/SkillReadiness/SkillReady")]
    public class SkillReadinessReadyAsset : SkillReadiness
    {

        public override void StatusAction(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillType = skillLogic.SkillAttributes.SkillType;
            
            //Active, CDPassive, Passive, and BasicSkill types
            logicTree.AddCurrent(skillType.SetSkillReady(skillLogic));
        }

        public override void ResetSkillCooldown(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ResetCooldownToMax());

        }
    }
}
