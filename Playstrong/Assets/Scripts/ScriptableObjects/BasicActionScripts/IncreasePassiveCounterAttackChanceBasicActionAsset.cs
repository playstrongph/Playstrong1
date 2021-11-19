using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveCounterAttackChance", menuName = "SO's/BasicActions/I/IncreasePassiveCounterAttackChance")]
    
    public class IncreasePassiveCounterAttackChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int counterChance;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CounterAttackChance += counterChance;
            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += counterChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.PassiveSkillHeroAttributes.CounterAttackChance += counterChance;
            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += counterChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CounterAttackChance -= counterChance;
            targetHero.HeroLogic.OtherAttributes.CounterAttackChance -= counterChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CounterAttackChance -= counterChance;
            targetHero.HeroLogic.OtherAttributes.CounterAttackChance -= counterChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
