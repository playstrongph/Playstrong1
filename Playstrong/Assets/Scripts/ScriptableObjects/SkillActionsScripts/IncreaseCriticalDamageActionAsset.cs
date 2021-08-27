using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCriticalDamage", menuName = "SO's/SkillActions/IncreaseCriticalDamageActionAsset")]
    
    public class IncreaseCriticalDamageActionAsset : SkillActionAsset
    {
        [SerializeField] private int criticalDamageIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            criticalDamageIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier += criticalDamageIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
