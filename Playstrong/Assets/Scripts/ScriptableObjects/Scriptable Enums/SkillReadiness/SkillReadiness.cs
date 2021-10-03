using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillReadiness
{
    public class SkillReadiness : ScriptableObject, ISkillReadiness
    {
        public virtual void StatusAction(ISkillLogic skillLogic)
        {
            
        }

        public virtual void StartAction(IHeroAction skillAction, IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skillAction.StartAction(thisHero,targetHero));
        }

        public virtual void ResetSkillCooldown(ISkill skill)
        {
        }

        
        
        public virtual IEnumerator SetCdPassiveSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        


    }
}
