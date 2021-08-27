using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
