using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseHealResistance", menuName = "SO's/SkillActions/IncreaseHealResistance")]
    
    public class IncreaseHealResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int healResistanceIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            healResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HealResistance += healResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
