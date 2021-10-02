﻿using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "SO's/Skill Type/Active Skill")]
    public class ActiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

        public override void ReduceSkillCd(ISkill skill, int counter)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ReduceCooldown(counter));
        }
        
        public override void ResetSkillCd(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddCurrent(skill.SkillLogic.ChangeSkillCooldown.ResetCooldown());
        }
        
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var skillReady = skillLogic.SkillAttributes.SkillReadiness;
            
            logicTree.AddCurrent(skillReady.SetActiveSkillReady(skillLogic));
            

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(skillLogic.ChangeSkillCooldown.SetSkillCdValue(counter));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator DisableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var skillNotReady = skill.SkillLogic.SkillReadiness.SkillNotReady;

            skill.SkillLogic.SkillAttributes.SkillReadiness = skillNotReady;
            skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);

            skill.SkillLogic.SkillAttributes.SkillEffect.UnregisterSkillEffect(skill);
            
            Debug.Log("Disable Active Skill: " +skill.SkillName);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnableActiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;
            var skillReady = skill.SkillLogic.SkillReadiness.SkillReady;

            if (skill.SkillLogic.SkillAttributes.Cooldown <= 0)
            {
                skill.SkillLogic.SkillAttributes.SkillReadiness = skillReady;
                skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill.SkillLogic);
            }
            
            //TEST
            skill.SkillLogic.SkillAttributes.SkillEffect.RegisterSkillEffect(skill);
            
            
            Debug.Log("Enable Active Skill: " +skill.SkillName);

            logicTree.EndSequence();
            yield return null;
        }
        

    }
}
