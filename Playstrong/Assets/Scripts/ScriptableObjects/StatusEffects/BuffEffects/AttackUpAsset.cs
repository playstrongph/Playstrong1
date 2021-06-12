using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset, IBuffEffectAsset
    {
        public override void ApplyStatusEffect()
        {
            Debug.Log("Attack Up Buff");       
        }

       

    }
}
