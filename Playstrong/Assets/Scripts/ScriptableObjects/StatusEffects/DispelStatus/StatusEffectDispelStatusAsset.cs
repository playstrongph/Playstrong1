using System.Collections.Generic;
using System.ComponentModel;
using Interfaces;
using Logic;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.Instance
{
    public class StatusEffectDispelAsset : ScriptableObject, IStatusEffectDispelStatusAsset
    {
        //Option 1
        //By Default, Status Effect is dispellable
        public virtual IHeroStatusEffect AddToDispelList(IHeroStatusEffect statusEffect)
        {
            return statusEffect;
        }
        
        ////Option 2 (favored)
        public virtual void UpdateDispelList(List<IHeroStatusEffect> dispelList, IHeroStatusEffect statusEffect)
        {
            dispelList.Add(statusEffect);
        }

    }
}
