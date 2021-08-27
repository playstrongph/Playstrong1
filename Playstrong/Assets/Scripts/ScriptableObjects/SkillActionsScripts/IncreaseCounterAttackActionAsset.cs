using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
