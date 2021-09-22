using Interfaces;
using References;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface IDamageAttributeMultipleAsset
    {
        int GetDamageMultiple(IHero targetHero);
    }
}