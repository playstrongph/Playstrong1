using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCounterAttackChance", menuName = "SO's/BasicActions/IncreaseCounterAttackChance")]
    
    public class IncreaseCounterAttackChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int counterAttackChanceIncrease;

       
        public override IEnumerator TargetAction(IHero targetHero, float value)
        {
            counterAttackChanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += counterAttackChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
