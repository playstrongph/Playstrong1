using System.Collections;
using Interfaces;
using References;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseAllBuffDurations", menuName = "SO's/SkillActions/IncreaseAllBuffDurations")]
    
    public class IncreaseAllBuffDurationsActionAsset : SkillActionAsset
    {
        [SerializeField] private int buffDurationIncrease;
        
        public override IEnumerator ActionTarget(IHero targetHero, float value)
        {
            buffDurationIncrease = (int)value;
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var coroutineTrees = targetHero.CoroutineTreesAsset;

            foreach (var buff in allBuffs)
            {
                buff.StatusEffectInstance.IncreaseCounters(buff, targetHero,buffDurationIncrease);
            }

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
