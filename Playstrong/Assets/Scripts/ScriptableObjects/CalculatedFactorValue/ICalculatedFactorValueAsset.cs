using Interfaces;
using References;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface ICalculatedFactorValueAsset
    {
        int GetDamageFactor(IHero hero);

        int GetDamageFactor(IHero thisHero, IHero targetHero);

        void SetCalculatedValue(IHero hero);

        void SetCalculatedValue(IHero thisHero, IHero targetHero);

        float GetCalculatedValue();
    }
}