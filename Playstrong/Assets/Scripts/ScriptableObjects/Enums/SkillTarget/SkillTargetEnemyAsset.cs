using System;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetEnemy", menuName = "SO's/Scriptable Enums/Skill Target/Skill Target Enemy")]
    public class SkillTargetEnemyAsset : ScriptableObject, ISkillTarget
    {
        //SetTarget(_getValidTargets, GetAllyTargets, GetEnemyTargets)
        
        public void SetTargets(Action getValidTargets, Action getAllyTargets, Action getEnemyTargets)
        {
            getValidTargets = getEnemyTargets;
        }


    }
}
