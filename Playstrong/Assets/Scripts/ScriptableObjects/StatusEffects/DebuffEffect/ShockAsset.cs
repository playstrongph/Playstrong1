using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Shock", menuName = "SO's/Status Effects/UniqueEffects/Shock")]
    public class ShockAsset : StatusEffectAsset
    {   
       
        public override void ApplyStatusEffect(IHero hero) 
        {
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }
    }
}
