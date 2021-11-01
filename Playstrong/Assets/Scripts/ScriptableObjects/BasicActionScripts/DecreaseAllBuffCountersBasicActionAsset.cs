using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "DecreaseAllBuffCounters", menuName = "SO's/BasicActions/DecreaseAllBuffCounters")]
    
    public class DecreaseAllBuffCountersBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int counters;

        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;

            foreach (var buff in buffs)
            {
                buff.DecreaseStatusEffectCounters.DecreaseCounters(counters);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;

            foreach (var buff in buffs)
            {
                buff.DecreaseStatusEffectCounters.DecreaseCounters(counters);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
       

      










    }
}
