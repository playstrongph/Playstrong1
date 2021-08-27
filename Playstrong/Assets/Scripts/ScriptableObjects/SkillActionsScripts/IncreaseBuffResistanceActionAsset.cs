using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
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
