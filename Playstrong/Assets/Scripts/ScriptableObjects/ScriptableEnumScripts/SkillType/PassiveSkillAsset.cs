
using System.Collections;
using Interfaces;
using Logic;
using References;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "SO's/Skill Type/Passive Skill")]
    public class PassiveSkillAsset : SkillType
    {
        public override void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = false;
        }
        
        public override void ReduceSkillCd(ISkill skill, int counter)
        {
           //Do nothing for Passive Skills
        }
        
        public override void ResetActiveSkillCd(ISkill skill)
        {
            //Do nothing for Passive Skills
        }
        
        public override IEnumerator SetSkillCdValue(ISkillLogic skillLogic, int counter)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            
            //Do nothing for Passive Skills

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator DisablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            skill.SkillLogic.UpdateSkillEnabledStatus.SkillDisabled.DisableSkill(skill);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator EnablePassiveSkill(ISkill skill)
        {
            var logicTree = skill.CoroutineTreesAsset.MainLogicTree;

            //skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled.EnableSkill(skill);
            logicTree.AddCurrent(EnablePassiveSkillCoroutine(skill));

            //TODO - Assess if this is also needed for CD Skill Passive
            logicTree.AddCurrent(AfterHeroEnablesPassiveSkillEvent(skill.Hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST
        public override IEnumerator SetSkillReady(ISkillLogic skillLogic)
        {
            var logicTree = skillLogic.Skill.CoroutineTreesAsset.MainLogicTree;
            var visualTree = skillLogic.Skill.CoroutineTreesAsset.MainVisualTree;
            
            
            visualTree.AddCurrent(HideCooldownText(skillLogic));

            logicTree.EndSequence();
            yield return null;
        }
        
        //Hero Event
        private IEnumerator AfterHeroEnablesPassiveSkillEvent(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.HeroEvents.AfterHeroEnablesPassiveSkill(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EnablePassiveSkillCoroutine(ISkill skill)
        {
            var logicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            
            skill.SkillLogic.UpdateSkillEnabledStatus.SkillEnabled.EnableSkill(skill);
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
