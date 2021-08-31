using System.Collections;
using Interfaces;
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

            foreach (var buff in allBuffs)
            {
                //TODO: Use IHeroAsset IncreaseStatusEffect Counters
                
                buff.Counters += buffDurationIncrease;
                buff.CounterVisual.text = buff.Counters.ToString();
            }

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
