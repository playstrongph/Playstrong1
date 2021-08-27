using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackTargetResistance", menuName = "SO's/SkillActions/IncreaseAttackTargetResistance")]
    
    public class IncreaseAttackTargetResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackTargetResistanceIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            attackTargetResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance += attackTargetResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
