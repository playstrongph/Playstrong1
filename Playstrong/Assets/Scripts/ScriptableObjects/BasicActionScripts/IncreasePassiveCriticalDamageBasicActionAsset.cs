using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreasePassiveCriticalDamage", menuName = "SO's/BasicActions/I/IncreasePassiveCriticalDamage")]
    
    public class IncreasePassiveCriticalDamageBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int criticalDamage;
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalDamageMultiplier += criticalDamage;
            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier += criticalDamage;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalDamageMultiplier += criticalDamage;
            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier += criticalDamage;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /*public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalDamageMultiplier -= criticalDamage;
            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier -= criticalDamage;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            targetHero.HeroLogic.PassiveSkillHeroAttributes.CriticalDamageMultiplier -= criticalDamage;
            targetHero.HeroLogic.OtherAttributes.CriticalDamageMultiplier -= criticalDamage;
            
            logicTree.EndSequence();
            yield return null;
        }*/

      










    }
}
