using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseCriticalResistance", menuName = "SO's/SkillActions/DecreaseCriticalResistance")]
    
    public class DecreaseCriticalResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int criticalResistanceIncrease;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            criticalResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance -= criticalResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
