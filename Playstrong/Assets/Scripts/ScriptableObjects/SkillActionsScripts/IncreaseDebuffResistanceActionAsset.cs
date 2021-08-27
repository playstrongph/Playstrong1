using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseDebuffResistanceActionAsset", menuName = "SO's/SkillActions/IncreaseDebuffResistanceActionAsset")]
    
    public class IncreaseDebuffResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int debuffResistanceIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            debuffResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffResistance += debuffResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
