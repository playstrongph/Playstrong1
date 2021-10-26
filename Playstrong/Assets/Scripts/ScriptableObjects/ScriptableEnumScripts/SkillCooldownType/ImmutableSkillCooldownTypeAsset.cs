using System.Collections;
using References;
using UnityEngine;


namespace ScriptableObjects.ScriptableEnumScripts.SkillCooldownType
{
    
    /// <summary>
    /// Skill Cooldown only reduces and resets normally during the hero's turn.
    /// </summary>
    [CreateAssetMenu(fileName = "ImmutableSkillCooldown", menuName = "SO's/Scriptable Enums/SkillCooldownType/ImmutableSkillCooldown")]
    public class ImmutableSkillCooldownTypeAsset : SkillCooldownTypeAsset
    {
        public override IEnumerator TurnReduceCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.TurnReduceCooldown(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator IncreaseCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            //logicTree.AddCurrent(base.IncreaseCooldown(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator SetSkillCdToValue(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //logicTree.AddCurrent(base.SetSkillCdToValue(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        
        public override IEnumerator TurnResetCooldownToMax(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.TurnResetCooldownToMax(skill));
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator RefreshCooldownToZero(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //logicTree.AddCurrent(base.RefreshCooldownToZero(skill));
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
