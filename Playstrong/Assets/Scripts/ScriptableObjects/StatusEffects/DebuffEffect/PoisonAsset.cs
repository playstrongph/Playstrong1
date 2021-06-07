using ScriptableObjects.Enums;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Poison", menuName = "SO's/Status Effects/Debuffs/Poison")]
    public class PoisonAsset : StatusEffectAsset, IDebuffEffect
    {
        public override void ApplyStatusEffect()
        {
            
        }

    }
}
