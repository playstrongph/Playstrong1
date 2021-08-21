﻿using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "DecreaseSkillCd", menuName = "SO's/SkillActions/DecreaseSkillCd")]
    
    public class DecreaseSkillCdActionAsset : SkillActionAsset
    {
        [SerializeField] private int skillCdDecrease;
        
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            skillCdDecrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var heroSkillsObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;

            foreach (var heroSkillObject in heroSkillsObjects)
            {
                var skill = heroSkillObject.GetComponent<ISkill>();
                var skillCd = skill.SkillLogic.SkillAttributes.Cooldown;
                var newSkillCd = skillCd - skillCdDecrease;
                
                skill.SkillLogic.ChangeSkillCooldown.SetCooldownValue(newSkillCd);
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
