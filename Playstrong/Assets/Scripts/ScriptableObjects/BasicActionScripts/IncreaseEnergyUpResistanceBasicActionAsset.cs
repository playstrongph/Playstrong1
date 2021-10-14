using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseEnergyUpResistance", menuName = "SO's/BasicActions/IncreaseEnergyUpResistance")]
    
    public class IncreaseEnergyUpResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int increaseResistance;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.EnergyUpResistance += increaseResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.EnergyUpResistance -= increaseResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
