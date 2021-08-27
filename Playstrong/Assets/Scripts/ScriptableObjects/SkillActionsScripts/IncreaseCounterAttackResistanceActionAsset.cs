using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCounterAttackResistanceActionAsset", menuName = "SO's/SkillActions/IncreaseCounterAttackResistanceActionAsset")]
    
    public class IncreaseCounterAttackResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int counterAttackResistanceIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            counterAttackResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackResistance += counterAttackResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
