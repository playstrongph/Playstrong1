using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DisablePassiveSkills", menuName = "SO's/BasicActions/D/DisablePassiveSkills")]
    
    public class DisablePassiveSkillsBasicActionAsset : BasicActionAsset
    {

        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           DisablePassiveSkills(targetHero);
            
           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            DisablePassiveSkills(targetHero);
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

           EnablePassiveSkills(targetHero);
           
           logicTree.EndSequence();
            yield return null;

        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            EnablePassiveSkills(targetHero);
           
            logicTree.EndSequence();
            yield return null;

        }


        private void DisablePassiveSkills(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TEST
            logicTree.AddCurrent(targetHero.HeroLogic.PassiveSkillHeroAttributes.DisablePassiveAttributes());
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.DisablePassiveSkill(skill));

            }
        }
        
       
        private void EnablePassiveSkills(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //TEST
            logicTree.AddCurrent(targetHero.HeroLogic.PassiveSkillHeroAttributes.EnablePassiveAttributes());
            
            var skillObjects = targetHero.HeroSkills.Skills.GetComponent<ISkillsPanel>().SkillList;
            foreach (var skillObject in skillObjects)
            {
                var skill = skillObject.GetComponent<ISkill>();
                logicTree.AddCurrent(skill.SkillLogic.SkillAttributes.SkillType.EnablePassiveSkill(skill));
              
            }

        }

    }
}
