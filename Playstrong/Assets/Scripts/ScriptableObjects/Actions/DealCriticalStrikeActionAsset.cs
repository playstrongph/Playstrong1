using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "DealCriticalStrike", menuName = "SO's/SkillActions/DealCriticalStrikeActionAsset")]
    
    public class DealCriticalStrikeActionAsset : SkillActionAsset
    {
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            //LogicTree.AddCurrent(AddBuffCoroutine(BuffAsset, BuffCounters));
            LogicTree.AddCurrent(DealCriticalStrikeCoroutine());
           
            LogicTree.EndSequence();
           yield return null;

        }

        private IEnumerator DealCriticalStrikeCoroutine()
        {
            //TargetHero or ThisHero?
            var criticalStrikeAttackIndex = 1;
            
            TargetHero.HeroLogic.BasicAttack.SetAttackIndex = criticalStrikeAttackIndex;
            
            LogicTree.EndSequence();
            yield return null;
        }
        


        /*private IEnumerator AddBuffCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
             BuffAsset.StatusEffectInstance.AddStatusEffect(TargetHero, statusEffectAsset, statusEffectCounters);
            
             LogicTree.EndSequence();
            yield return null;
        }*/



      


    }
}
