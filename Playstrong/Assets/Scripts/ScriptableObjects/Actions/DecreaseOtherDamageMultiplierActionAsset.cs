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
    [CreateAssetMenu(fileName = "DecreaseOtherDamageMultiplier", menuName = "SO's/SkillActions/DecreaseOtherDamageMultiplier")]
    
    public class DecreaseOtherDamageMultiplierActionAsset : SkillActionAsset
    {
        [SerializeField] private int decreaseOtherDamageMultiplier;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            decreaseOtherDamageMultiplier = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.OtherDamageMultiplier -= decreaseOtherDamageMultiplier;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
