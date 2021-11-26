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
           var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
           var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
           var uniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;
           
           allStatusEffects.AddRange(buffs);
           allStatusEffects.AddRange(debuffs);
           allStatusEffects.AddRange(uniqueEffects);
            
           
           
           foreach (var statusEffect in allStatusEffects)
           {
               
               if (statusEffect.Name == SpecificStatusEffectAsset.Name)
                   _statusEffect = statusEffect;
               
           }
           
           
           

        

           if (_statusEffect != null)
           {
               Debug.Log("TriggerStatusEffect 1: " +_statusEffect.Name);
               
               foreach (var standardAction in _statusEffect.StatusEffectAsset.StandardActions)
               {
                   standardAction.StartAction(targetHero);
               }
               
               
               _statusEffect.DecreaseStatusEffectCounters.DecreaseCounters(1);
           }

           logicTree.EndSequence();
           yield return null;

        }
        
        public override IEnumerator TargetAction(IHero thisHero,IHero targetHero)
        {  
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            var allStatusEffects = new List<IHeroStatusEffect>();
            var buffs = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var uniqueEffects = targetHero.HeroStatusEffects.HeroUniqueEffects.UniqueEffects;
           
            allStatusEffects.AddRange(buffs);
            allStatusEffects.AddRange(debuffs);
            allStatusEffects.AddRange(uniqueEffects);
            
            
            
            foreach (var statusEffect in allStatusEffects)
            {
              
                if (statusEffect.Name == SpecificStatusEffectAsset.Name)
                    _statusEffect = statusEffect;
            }
            
            if (_statusEffect != null)
            {
                Debug.Log("TriggerStatusEffect 2: " +_statusEffect.Name);
                //_statusEffect.StatusEffectAsset.ApplyStatusEffect(targetHero);
                foreach (var standardAction in _statusEffect.StatusEffectAsset.StandardActions)
                {
                    standardAction.StartAction(thisHero,targetHero);
                }

                _statusEffect.DecreaseStatusEffectCounters.DecreaseCounters(1);
            }


            logicTree.EndSequence();
            yield return null;

        }

       

      


    }
}
