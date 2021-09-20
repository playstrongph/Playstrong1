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
        [SerializeField] private int counterAttackResistanceIncrease;

       
        public override IEnumerator TargetAction(IHero targetHero, IHero dummyHero)
        {
            //counterAttackResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance -= counterAttackResistanceIncrease;
            Debug.Log("Counter Attack Resistance" +targetHero.HeroLogic.OtherAttributes.CounterAttackResistance);
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
