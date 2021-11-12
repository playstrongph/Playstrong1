using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StandardActions;
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


        /// <summary>
        /// Executes StartAction for skills when skill is Ready
        /// </summary>
        public virtual void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero thisHero, IHero targetHero)
        {
            Debug.Log("Skill Not Ready SkillStartAction");
            
        }
        
        /// <summary>
        /// Executes StartAction for skills when skill is Ready
        /// </summary>
        public virtual void SkillStartAction(ISkillStandardActionAsset skillStandardActionAsset, IHero targetHero)
        {
            Debug.Log("Skill Not Ready SkillStartAction");
        }
        
        
        /*public virtual void ResetSkillCooldown(ISkill skill)
        {
        }*/
        /*public virtual IEnumerator SetCdPassiveSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }*/
        
        


    }
}
