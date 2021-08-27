using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAttackTargetChance", menuName = "SO's/SkillActions/IncreaseAttackTargetChance")]
    
    public class IncreaseAttackTargetChanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackTargetChanceIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            attackTargetChanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetChance += attackTargetChanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
