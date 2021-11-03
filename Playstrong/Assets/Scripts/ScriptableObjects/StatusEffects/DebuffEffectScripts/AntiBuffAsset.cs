using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "AntiBuff", menuName = "SO's/Status Effects/Debuffs/AntiBuff")]
    public class AntiBuffAsset : StatusEffectAsset
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
