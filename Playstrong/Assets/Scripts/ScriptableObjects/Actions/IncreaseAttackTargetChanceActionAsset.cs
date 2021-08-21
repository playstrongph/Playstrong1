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
