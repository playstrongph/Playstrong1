using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseHealResistance", menuName = "SO's/BasicActions/I/IncreaseHealResistance")]
    
    public class IncreaseHealResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int healResistance;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HealResistance += healResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.HealResistance -= healResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
