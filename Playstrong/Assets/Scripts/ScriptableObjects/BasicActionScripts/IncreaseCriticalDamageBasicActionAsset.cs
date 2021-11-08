using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseCriticalDamage", menuName = "SO's/BasicActions/I/IncreaseCriticalDamage")]
    
    public class IncreaseCriticalDamageBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int critDamage;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier += critDamage;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier -= critDamage;
            
            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
