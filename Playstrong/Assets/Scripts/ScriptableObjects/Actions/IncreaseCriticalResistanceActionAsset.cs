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
    [CreateAssetMenu(fileName = "IncreaseCriticalResistanceActionAsset", menuName = "SO's/SkillActions/IncreaseCriticalResistanceActionAsset")]
    
    public class IncreaseCriticalResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int criticalResistanceIncrease;

       
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            criticalResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance += criticalResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
