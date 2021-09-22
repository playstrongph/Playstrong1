using Interfaces;
using References;
using UnityEngine;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public class DamageAttributeMultipleAsset : ScriptableObject, IDamageAttributeMultipleAsset
    {

        public virtual int GetDamageMultiple(IHero targetHero)
        {
            var damageMultiple = 0;
            return damageMultiple;
        }


    }
}
