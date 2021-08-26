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
