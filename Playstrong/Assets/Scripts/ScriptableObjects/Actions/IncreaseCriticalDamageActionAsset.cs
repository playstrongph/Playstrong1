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
    [CreateAssetMenu(fileName = "IncreaseCriticalDamage", menuName = "SO's/SkillActions/IncreaseCriticalDamageActionAsset")]
    
    public class IncreaseCriticalDamageActionAsset : SkillActionAsset
    {
        [SerializeField] private int criticalDamageIncrease;

        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            criticalDamageIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier += criticalDamageIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
