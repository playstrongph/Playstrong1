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
    [CreateAssetMenu(fileName = "IncreaseAttackTargetResistance", menuName = "SO's/SkillActions/IncreaseAttackTargetResistance")]
    
    public class IncreaseAttackTargetResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int attackTargetResistanceIncrease;

        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            attackTargetResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.AttackTargetResistance += attackTargetResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
