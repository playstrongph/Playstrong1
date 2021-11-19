using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveAttackTargetResistance", menuName = "SO's/BasicActions/I/IncreasePassiveAttackTargetResistance")]
    
    public class IncreasePassiveAttackTargetResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int attackTargetResistance;

        public override IEnumerator TargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.AttackTargetResistance += attackTargetResistance;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance += attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        } 
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.AttackTargetResistance += attackTargetResistance;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance += attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        } 
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.AttackTargetResistance -= attackTargetResistance;
            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance -= attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.AttackTargetResistance -= attackTargetResistance;
            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance -= attackTargetResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
