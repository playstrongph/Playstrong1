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
    [CreateAssetMenu(fileName = "DispelRandomDebuffs", menuName = "SO's/BasicActions/D/DispelRandomDebuffs")]
    
    public class DispelRandomDebuffsBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int dispelCount;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            
           

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            //var debuffs = ShuffleStatusEffectsList(targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs);
            
            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;


            var count = Mathf.Min(dispelCount, debuffs.Count);
            
            Debug.Log("DispelDebuffs targetHero: " +targetHero.HeroName +" Debuffs Count: " +debuffs.Count +" Dispel Count: " +dispelCount +" count: " +count );

            for (int i = 0; i < count; i++)
            {
                debuffs[i].StatusEffectDispelStatus.DispelStatusEffect(debuffs[i],targetHero);
            }

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {

            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            //var debuffs = ShuffleStatusEffectsList(targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs);
            
            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;

            var count = Mathf.Min(dispelCount, debuffs.Count);

            Debug.Log("DispelDebuffs targetHero: " +targetHero.HeroName +" Debuffs Count: " +debuffs.Count +" Dispel Count: " +dispelCount +" count: " +count );

            for (int i = 0; i < count; i++)
            {
                debuffs[i].StatusEffectDispelStatus.DispelStatusEffect(debuffs[i],targetHero);
            }

            logicTree.EndSequence();
            yield return null;
        }


       
      










    }
}
