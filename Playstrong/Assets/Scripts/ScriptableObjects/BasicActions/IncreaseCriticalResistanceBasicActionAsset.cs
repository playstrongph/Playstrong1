using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCriticalResistanceBasicAction", menuName = "SO's/BasicActions/IncreaseCriticalResistanceBasicAction")]
    
    public class IncreaseCriticalResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalResistanceIncrease;

       
        public override IEnumerator TargetAction(IHero targetHero, float value)
        {
            criticalResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance += criticalResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
