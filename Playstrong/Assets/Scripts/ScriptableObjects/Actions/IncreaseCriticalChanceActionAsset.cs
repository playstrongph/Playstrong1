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
    [CreateAssetMenu(fileName = "IncreaseCriticalChance", menuName = "SO's/SkillActions/IncreaseCriticalChance")]
    
    public class IncreaseCriticalChanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int criticalChanceIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            criticalChanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
