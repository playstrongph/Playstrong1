using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCriticalResistanceBasicAction", menuName = "SO's/BasicActions/IncreaseCriticalResistanceBasicAction")]
    
    public class IncreaseCriticalResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalResistance;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance += criticalResistance;

            logicTree.EndSequence();
            yield return null;
        }


        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalStrikeResistance -= criticalResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
