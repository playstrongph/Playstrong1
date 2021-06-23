using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset
    {
        public override void ApplyStatusEffect()
        {
            Debug.Log("Attack Up Buff");       
        }
        
        public override void UnapplyStatusEffect()
        {
            Debug.Log("Unapply Attack Up Buff");       
        }
        
        

       

    }
}
