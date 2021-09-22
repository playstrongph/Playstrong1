using Interfaces;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface ICalculatedValueAsset
    {
        void SetCalculatedValue(IHero targetHero);
        void SetCalculatedValue(IHero thisHero, IHero targetHero);
        float GetCalculatedValue();
    }
}