using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
{
    [CreateAssetMenu(fileName = "SkillStatusNotReady", menuName = "SO's/Scriptable Enums/Skill Status/Skill Status NotReady")]
    public class SkillReadinessNotReadyAsset : SkillReadiness
    {
        public override void StatusAction(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillType = skillLogic.SkillAttributes.SkillType;
            
            logicTree.AddCurrent(skillType.SetSkillNotReady(skillLogic));
        }


        public override void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero)
        {
            //Don't perform default action
        }
        
        
        
        
        
      

    }
}
