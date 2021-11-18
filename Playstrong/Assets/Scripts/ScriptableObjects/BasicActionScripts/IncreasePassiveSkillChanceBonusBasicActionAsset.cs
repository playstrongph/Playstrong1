using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveSkillChanceBonus", menuName = "SO's/BasicActions/I/IncreasePassiveSkillChanceBonus")]
    
    public class IncreasePassiveSkillChanceBonusBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int skillChanceBonus;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.SkillChanceBonus += skillChanceBonus;

            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus += skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.SkillChanceBonus += skillChanceBonus;
            
            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus += skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.SkillChanceBonus -= skillChanceBonus;
            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus -= skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.SkillChanceBonus -= skillChanceBonus;
            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus -= skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
