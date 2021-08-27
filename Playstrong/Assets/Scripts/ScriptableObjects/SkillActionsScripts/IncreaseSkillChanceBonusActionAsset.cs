using System.Collections;
using Interfaces;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseSkillChanceBonus", menuName = "SO's/SkillActions/IncreaseSkillChanceBonus")]
    
    public class IncreaseSkillChanceBonusActionAsset : SkillActionAsset
    {
        [SerializeField] private int skillChanceBonusIncrease;

       
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            skillChanceBonusIncrease = (int)value;
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus += skillChanceBonusIncrease;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
