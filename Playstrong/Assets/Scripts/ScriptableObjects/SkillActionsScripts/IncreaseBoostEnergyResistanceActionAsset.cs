using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseBoostEnergyResistance", menuName = "SO's/SkillActions/IncreaseBoostEnergyResistance")]
    
    public class IncreaseBoostEnergyResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int boostResistanceIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            boostResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.BuffResistance += boostResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
