using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseSkillChanceBonus", menuName = "SO's/BasicActions/IncreaseSkillChanceBonus")]
    
    public class IncreaseSkillChanceBonusBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int skillChanceBonus;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus += skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.SkillChanceBonus -= skillChanceBonus;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
