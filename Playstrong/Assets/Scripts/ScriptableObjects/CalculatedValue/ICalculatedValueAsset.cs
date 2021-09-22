using Interfaces;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface ICalculatedValueAsset
    {
        void SetCalculatedValue(IHero targetHero);
        float GetCalculatedValue();
    }
}