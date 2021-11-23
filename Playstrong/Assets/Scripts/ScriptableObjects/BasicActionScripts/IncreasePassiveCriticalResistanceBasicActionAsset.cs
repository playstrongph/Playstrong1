using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveCriticalStrikeResistance", menuName = "SO's/BasicActions/I/IncreasePassiveCriticalStrikeResistance")]
    
    public class IncreasePassiveCriticalResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalResistance;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalStrikeResistance += criticalResistance;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance += criticalResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalStrikeResistance += criticalResistance;
            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance += criticalResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
