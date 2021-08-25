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
    [CreateAssetMenu(fileName = "IncreaseBuffResistance", menuName = "SO's/SkillActions/IncreaseBuffResistance")]
    
    public class IncreaseBuffResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int buffResistanceIncrease;

        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            buffResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.BuffResistance += buffResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
