using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
        [CreateAssetMenu(fileName = "DispelRandomBuffs", menuName = "SO's/BasicActions/D/DispelRandomBuffs")]

    public class DispelRandomBuffsBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int dispelCount;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var buffs = ShuffleStatusEffectsList(targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs);

            var count = Mathf.Min(dispelCount, buffs.Count);

            for (int i = 0; i < count; i++)
            {
                buffs[i].StatusEffectDispelStatus.DispelStatusEffect(buffs[i],targetHero);
            }

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            var buffs = ShuffleStatusEffectsList(targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs);

            var count = Mathf.Min(dispelCount, buffs.Count);

            for (int i = 0; i < count; i++)
            {
                buffs[i].StatusEffectDispelStatus.DispelStatusEffect(buffs[i],targetHero);
            }

            logicTree.EndSequence();
            yield return null;
        }


       
      










    }
}
