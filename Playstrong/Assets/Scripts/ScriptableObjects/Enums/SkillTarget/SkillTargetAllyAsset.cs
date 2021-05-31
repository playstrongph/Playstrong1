using System;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetAlly", menuName = "SO's/Scriptable Enums/Skill Target/Skill Target Ally")]
    public class SkillTargetAllyAsset : ScriptableObject, ISkillTarget
    {
        
        public void SetTargets(Action getValidTargets, Action getAllyTargets, Action getEnemyTargets)
        {
            getValidTargets = getAllyTargets;
        }

    }
}
