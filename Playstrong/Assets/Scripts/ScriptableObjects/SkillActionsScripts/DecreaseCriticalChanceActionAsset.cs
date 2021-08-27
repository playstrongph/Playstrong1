using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseCriticalChance", menuName = "SO's/SkillActions/DecreaseCriticalChance")]
    
    public class DecreaseCriticalChanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int decreaseCriticalChance;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            decreaseCriticalChance = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance -= decreaseCriticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
