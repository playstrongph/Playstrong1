using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status Ready")]
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
            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ResetCooldown());

        }
    }
}
