using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
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
