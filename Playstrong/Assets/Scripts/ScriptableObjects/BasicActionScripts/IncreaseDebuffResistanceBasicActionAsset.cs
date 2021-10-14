using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseDebuffResistance", menuName = "SO's/BasicActions/IncreaseDebuffResistance")]
    
    public class IncreaseDebuffResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int debuffResistance;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffResistance += debuffResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.DebuffResistance -= debuffResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
