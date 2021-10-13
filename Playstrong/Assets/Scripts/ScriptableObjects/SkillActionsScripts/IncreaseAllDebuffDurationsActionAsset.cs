using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAllDebuffDurations", menuName = "SO's/SkillActions/IncreaseAllDebuffDurations")]
    
    public class IncreaseAllDebuffDurationsActionAsset : SkillActionAsset
    {
        [SerializeField] private int debuffDurationIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            debuffDurationIncrease = (int)value;
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var allDebuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var coroutineTrees = targetHero.CoroutineTreesAsset;

            foreach (var debuff in allDebuffs)
            {
                //debuff.StatusEffectInstance.IncreaseCounters(debuff, targetHero,debuffDurationIncrease);
                debuff.StatusEffectChangeCounters.IncreaseStatusEffectCounters(debuff,debuffDurationIncrease);
            }

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
