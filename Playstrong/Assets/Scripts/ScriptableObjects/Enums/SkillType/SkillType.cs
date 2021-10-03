using System.Collections;
using Interfaces;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    public class SkillType : ScriptableObject, ISkillType
    {
        public virtual void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            //set cooldown.enabled status
        }

        public virtual void ReduceSkillCd(ISkill skill, int counter)
        {
            //No action for Passive Skills
            //ReduceCd for Active Skills
            //ReduceCD for CdPassiveSkills
        }

        public virtual void ResetSkillCd(ISkill skill)
        {
            //No action for Passive Skills
            //Max Cooldown for Active Skills
            //Max Cooldown for CdPassive Skills
        }
        
        
        //For CD Passive and Active skills
        public virtual IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;


            logicTree.EndSequence();
            yield return null;
        }
        
        //For CD Passive and Active skills
        public virtual IEnumerator SetSkillNotReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }


        public virtual IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST SILENCE and SEAL
        public virtual IEnumerator DisableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator EnableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator DisablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        public virtual IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            //
            
            logicTree.EndSequence();
            yield return null;
        }
        
        



    }
}
