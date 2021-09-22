using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public class DamageAttributeMultipleAsset : ScriptableObject, IDamageAttributeMultipleAsset
    {
        [SerializeField] private ScriptableObject targetMultiple;
        public IActionTargets TargetMultiple => targetMultiple as IActionTargets;
        
        public virtual int GetDamageMultiple(IHero hero)
        {
            var damageMultiple = 0;
            return damageMultiple;
        }
        
        public virtual int GetDamageMultiple(IHero thisHero, IHero targetHero)
        {
            var damageMultiple = 0;
            return damageMultiple;
        }


    }
}
