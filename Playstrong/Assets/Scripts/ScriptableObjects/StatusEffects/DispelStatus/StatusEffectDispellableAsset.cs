using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    
    [CreateAssetMenu(fileName = "NotDispellable", menuName = "SO's/Status Effects/DispelStatus/NotDispellable")]
    public class StatusEffectDispellableAsset : StatusEffectDispelAsset
    {
        
        //Option 1
        public override IHeroStatusEffect AddToDispelList(IHeroStatusEffect statusEffect)
        {
            return null;
        }
        
        //Option 2
        public override void UpdateDispelList(List<IHeroStatusEffect> dispelList, IHeroStatusEffect statusEffect)
        {
            //Don't update the DispelList
        }

    }
}
