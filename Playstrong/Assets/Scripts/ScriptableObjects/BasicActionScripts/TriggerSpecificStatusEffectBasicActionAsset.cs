using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "TriggerSpecificStatusEffect", menuName = "SO's/BasicActions/T/TriggerSpecificStatusEffect")]
    
    public class TriggerSpecificStatusEffectBasicActionAsset : BasicActionAsset
    {

        [SerializeField] private ScriptableObject specificStatusEffectAsset;
        public IStatusEffectAsset SpecificStatusEffectAsset => specificStatusEffectAsset as IStatusEffectAsset;

        private IHeroStatusEffect _statusEffect;

        public override IEnumerator TargetAction(IHero targetHero)
        {
           var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           
           var allStatusEffects = new List<IHeroStatusEffect>();
           var triggerStatusEffects = new List<IHeroStatusEffect>();
           var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
           var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
           var uniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

           allStatusEffects.AddRange(buffs);
           allStatusEffects.AddRange(debuffs);
           allStatusEffects.AddRange(uniqueEffects);

           //Fina all statusEffects
           foreach (var statusEffect in allStatusEffects)
           {
               if (statusEffect.Name == SpecificStatusEffectAsset.Name)
                   triggerStatusEffects.Add(statusEffect);
           }
            
           //Trigger Status Effect
           foreach (var statusEffect in triggerStatusEffects)
           {
               foreach (var standardAction in statusEffect.StatusEffectAsset.StandardActions)
               {
                   standardAction.StartAction(targetHero);
               }
                
               statusEffect.DecreaseStatusEffectCounters.DecreaseCounters(1);

           }

           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {  
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var allStatusEffects = new List<IHeroStatusEffect>();
            var triggerStatusEffects = new List<IHeroStatusEffect>();
            var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var uniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;

            allStatusEffects.AddRange(buffs);
            allStatusEffects.AddRange(debuffs);
            allStatusEffects.AddRange(uniqueEffects);

            //Fina all statusEffects
            foreach (var statusEffect in allStatusEffects)
            {
                if (statusEffect.Name == SpecificStatusEffectAsset.Name)
                    triggerStatusEffects.Add(statusEffect);
            }
            
            //Trigger Status Effect
            foreach (var statusEffect in triggerStatusEffects)
            {
                foreach (var standardAction in statusEffect.StatusEffectAsset.StandardActions)
                {
                    standardAction.StartAction(thisHero,targetHero);
                }
                
                statusEffect.DecreaseStatusEffectCounters.DecreaseCounters(1);

            }

            logicTree.EndSequence();
            yield return null;

        }

       

      


    }
}
