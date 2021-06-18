using System;
using UnityEngine;

namespace Logic
{
    public class UpdateStatusEffectCounters : MonoBehaviour
    {

        private IHeroStatusEffects _heroStatusEffects;
        private void Awake()
        {
            _heroStatusEffects = GetComponent<IHeroStatusEffects>();
        }
        
        
        
        
    }
}
