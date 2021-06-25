using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "AttackUp", menuName = "SO's/Status Effects/Buffs/AttackUp")]
    public class AttackUpAsset : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero)
        {
            Debug.Log("Attack Up Buff");       
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            Debug.Log("Unapply Attack Up Buff");       
        }
        
        

       

    }
}
