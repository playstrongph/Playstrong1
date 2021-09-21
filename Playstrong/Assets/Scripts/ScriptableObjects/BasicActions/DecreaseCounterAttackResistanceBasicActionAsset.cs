using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseCounterAttackResistance", menuName = "SO's/BasicActions/DecreaseCounterAttackResistance")]
    
    public class DecreaseCounterAttackResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int counterResistance;

       
        public override IEnumerator TargetAction(IHero targetHero, IHero dummyHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance -= counterResistance;
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero, IHero dummyHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance += counterResistance;

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
