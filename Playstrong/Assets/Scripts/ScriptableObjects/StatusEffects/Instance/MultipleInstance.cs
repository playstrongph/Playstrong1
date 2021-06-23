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
        public override void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            CreateStatusEffect(hero, statusEffectAsset, statusEffectCounters);
        }

       

      
        
        
    }
}
