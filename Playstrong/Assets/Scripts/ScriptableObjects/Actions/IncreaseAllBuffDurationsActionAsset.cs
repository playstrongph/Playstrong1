using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "IncreaseAllBuffDurations", menuName = "SO's/SkillActions/IncreaseAllBuffDurations")]
    
    public class IncreaseAllBuffDurationsActionAsset : SkillActionAsset
    {
        [SerializeField] private int buffDurationIncrease;
        
        public override IEnumerator StartAction(IHero targetHero, float value)
        {
            buffDurationIncrease = (int)value;
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var allBuffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;

            foreach (var buff in allBuffs)
            {
                var newBuffCounters = buff.Counters + buffDurationIncrease;
                buff.SetStatusEffectCounters.SetCounters(newBuffCounters,targetHero.CoroutineTreesAsset);
            }

            logicTree.EndSequence();
            yield return null;
        }

      










    }
}
