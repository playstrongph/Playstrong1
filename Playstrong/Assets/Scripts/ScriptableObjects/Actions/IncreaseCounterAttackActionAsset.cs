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
    [CreateAssetMenu(fileName = "IncreaseCounterAttackActionAsset", menuName = "SO's/SkillActions/IncreaseCounterAttackActionAsset")]
    
    public class IncreaseCounterAttackActionAsset : SkillActionAsset
    {
        [SerializeField] private int counterAttackChanceIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            counterAttackChanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CounterAttackChance += counterAttackChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
