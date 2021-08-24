using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "MultipleInstance", menuName = "SO's/Status Effects/Instance/Multiple Instance")]
    public class MultipleInstance : StatusEffectInstance
    {
       

        /// <summary> 
        /// Always Create a new status effect  
        /// </summary>
        public override void AddStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero casterHero)
        {
            NewStatusEffect = CreateStatusEffect(targetHero, statusEffectAsset, statusEffectCounters, casterHero);
            
                //Logic for "other" status effects - armor, increase energy, etc.
                if(NewStatusEffect.Counters <= 0)
                    NewStatusEffect.RemoveStatusEffect.RemoveEffect(targetHero);
        }

       

      
        
        
    }
}
