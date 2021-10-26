using System.Collections;
using References;
using UnityEngine;


namespace ScriptableObjects.ScriptableEnumScripts.SkillCooldownType
{
    [CreateAssetMenu(fileName = "NormalSkillCooldown", menuName = "SO's/Scriptable Enums/SkillCooldownType/NormalSkillCooldown")]
    public class NormalSkillCooldownTypeAsset : SkillCooldownTypeAsset
    {
        public override IEnumerator ReduceCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.ReduceCooldown(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator IncreaseCooldown(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(base.IncreaseCooldown(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator SetSkillCdToValue(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.SetSkillCdToValue(skill,counter));
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator ResetCooldownToMax(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.ResetCooldownToMax(skill));
            
            logicTree.EndSequence();
            yield return null;
        }

        public override IEnumerator RefreshCooldownToZero(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(base.RefreshCooldownToZero(skill));
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
