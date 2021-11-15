using Interfaces;
using References;
using ScriptableObjects.Scriptable_Enums.SkillReadiness;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillReady", menuName = "SO's/Scriptable Enums/SkillReadiness/SkillReady")]
    public class SkillReadinessReadyAsset : SkillReadiness
    {

        public override void StatusAction(ISkillLogic skillLogic)
        {
            Debug.Log("Skill Readiness Ready Asset Status Action: " +skillLogic.Skill.SkillName);
            
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillType = skillLogic.SkillAttributes.SkillType;
            
            //Active, CDPassive, Passive, and BasicSkill types
            logicTree.AddCurrent(skillType.SetSkillReady(skillLogic));
        }

        public override void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero thisHero, IHero targetHero)
        {
            Debug.Log("Skill Ready SkillStartAction: ");
            skillStandardActionAsset.SkillStartActionCoroutines(thisHero,targetHero);
            
        }
        
        
        public override void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero targetHero)
        {
            Debug.Log("Skill Ready SkillStartAction");
            skillStandardActionAsset.SkillStartActionCoroutines(targetHero);
        }
        
        
        /*public override void ResetSkillCooldown(ISkill skill)
       {
           var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
           logicTree.AddCurrent(skill.SkillLogic.UpdateSkillCooldown.TurnResetCooldownToMax());

       }*/
        
    }
}
