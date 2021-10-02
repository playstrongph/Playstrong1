using System.Collections;
using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillStatus
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

        public virtual IEnumerator SetActiveSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator SetCdPassiveSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        


    }
}
