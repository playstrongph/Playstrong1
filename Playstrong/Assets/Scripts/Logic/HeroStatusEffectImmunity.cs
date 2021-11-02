using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Hero percentage immunity to status effects.
    /// Full immunity represented at 500%.
    /// </summary>
    [CreateAssetMenu(fileName = "HeroImmunity", menuName = "SO's/HeroImmunities/HeroImmunity")]
    public class HeroStatusEffectImmunity : ScriptableObject, IHeroStatusEffectImmunity
    {
        [SerializeField] private int immunityPercentage;
        public int ImmunityPercentage => immunityPercentage;
        
        [SerializeField] private ScriptableObject statusEffect;
        
        public IStatusEffectAsset StatusEffectAsset => statusEffect as IStatusEffectAsset;
    }
}
