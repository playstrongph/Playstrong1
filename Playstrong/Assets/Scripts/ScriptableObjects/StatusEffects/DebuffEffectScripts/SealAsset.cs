using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Seal", menuName = "SO's/Status Effects/Debuffs/Seal")]
    public class SealAsset : StatusEffectAsset
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
