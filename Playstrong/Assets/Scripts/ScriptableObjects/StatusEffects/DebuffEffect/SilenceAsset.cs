using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Silence", menuName = "SO's/Status Effects/Debuffs/Silence")]
    public class SilenceAsset : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn += ApplySilenceEffect;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn -= ApplySilenceEffect;
            RemoveSilenceEffect(hero);
        }

        //Hard coding test first
        //TODO:  transfer to action - DisableAllActiveSkills
        private void ApplySilenceEffect(IHero hero)
        {   
            //var skills = new List<ISkill>();
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.DisableActiveSkill(skill));

            }
        }
        private void RemoveSilenceEffect(IHero hero)
        {   
            //var skills = new List<ISkill>();
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            var skillObjects = hero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.EnableActiveSkill(skill));

            }
        }








    }
}
