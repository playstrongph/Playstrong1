using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "Dispellable", menuName = "SO's/Status Effects/DispelStatus/Dispellable")]
    public class StatusEffectDispellableAsset : StatusEffectDispelAsset
    {
        
        //Option 1
        public override IHeroStatusEffect AddToDispelList(IHeroStatusEffect statusEffect)
        {
            return base.AddToDispelList(statusEffect);
        }
        
        //Option 2
        public override void UpdateDispelList(List<IHeroStatusEffect> dispelList, IHeroStatusEffect statusEffect)
        {
            base.UpdateDispelList(dispelList,statusEffect);
        }
        
        public override void DispelStatusEffect(IHeroStatusEffect existingStatusEffect, IHero targetHero)
        {
            base.DispelStatusEffect(existingStatusEffect,targetHero);
        }
        
        

    }
}
