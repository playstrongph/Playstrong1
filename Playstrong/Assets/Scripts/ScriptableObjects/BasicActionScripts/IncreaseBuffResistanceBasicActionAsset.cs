using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseBuffResistance", menuName = "SO's/BasicActions/IncreaseBuffResistance")]
    
    public class IncreaseBuffResistanceBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int buffResistance;

        public override IEnumerator TargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.BuffResistance += buffResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.BuffResistance -= buffResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
