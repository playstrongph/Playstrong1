using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveCriticalStrikeChance", menuName = "SO's/BasicActions/I/IncreasePassiveCriticalStrikeChance")]
    
    public class IncreasePassiveCriticalChanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalChance;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalStrikeChance += criticalChance;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalStrikeChance += criticalChance;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeChance += criticalChance;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
