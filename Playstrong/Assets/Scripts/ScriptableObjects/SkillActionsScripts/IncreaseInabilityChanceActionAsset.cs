using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseInabilityChance", menuName = "SO's/SkillActions/IncreaseInabilityChance")]
    
    public class IncreaseInabilityChanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int inabilityChanceIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            inabilityChanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HeroInabilityChance += inabilityChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
