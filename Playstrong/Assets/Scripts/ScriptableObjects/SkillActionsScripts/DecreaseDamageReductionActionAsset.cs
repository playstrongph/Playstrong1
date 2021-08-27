using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseDamageReductionAction", menuName = "SO's/SkillActions/DecreaseDamageReductionAction")]
    
    
    
    public class DecreaseDamageReductionActionAsset : SkillActionAsset
    {
        [SerializeField] private int damageReductionValue;
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            damageReductionValue = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var otherAttributes = targetHero.HeroLogic.OtherAttributes;

            otherAttributes.DamageReduction -= damageReductionValue;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
