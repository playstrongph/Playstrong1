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
    [CreateAssetMenu(fileName = "IncreaseDebuffResistanceActionAsset", menuName = "SO's/SkillActions/IncreaseDebuffResistanceActionAsset")]
    
    public class IncreaseDebuffResistanceActionAsset : SkillActionAsset
    {
        [SerializeField] private int debuffResistanceIncrease;

       
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            debuffResistanceIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffResistance += debuffResistanceIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
