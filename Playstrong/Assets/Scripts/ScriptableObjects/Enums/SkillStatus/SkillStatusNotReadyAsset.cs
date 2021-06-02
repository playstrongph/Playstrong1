using System.Collections;
using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusNotReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status NotReady")]
    public class SkillStatusNotReadyAsset : ScriptableObject, ISkillStatus
    {


        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        public void SkillNotReady(ISkill skill)
        {
            _logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            _visualTree = skill.CoroutineTreesAsset.MainVisualTree;
        }

        private IEnumerator SetSkillNotReady()
        {
            
            //DisableSkillTargetting
            //Disable
            
            
            _logicTree.EndSequence();
            yield return null;
        }


    }
}
