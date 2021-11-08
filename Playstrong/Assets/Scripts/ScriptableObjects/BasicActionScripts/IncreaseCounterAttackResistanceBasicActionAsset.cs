using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCounterAttackResistanceActionAsset", menuName = "SO's/BasicActions/I/IncreaseCounterAttackResistanceActionAsset")]
    
    public class IncreaseCounterAttackResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int counterResistance;
        public override IEnumerator TargetAction(IHero targetHero, IHero dummyHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance += counterResistance;
            
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
