using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class SkillAttackActionAsset : SkillActionAsset
    {
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //PreSkilLAttackEvents
            //PreAttackEvents
            //StartAttackActions
            //PostAttackEvents
            //PostSkillAttackEvents

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PreAttackEvents(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            thisHero.HeroLogic.HeroEvents.BeforeAttacking(thisHero, targetHero);
            targetHero.HeroLogic.HeroEvents.PreAttack(targetHero,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        

       



      


    }
}
