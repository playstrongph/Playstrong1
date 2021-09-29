using Interfaces;
using References;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface ICalculatedFactorValue
    {
        int GetDamageMultiple(IHero hero);

        int GetDamageMultiple(IHero thisHero, IHero targetHero);

        void SetCalculatedValue(IHero hero);

        void SetCalculatedValue(IHero thisHero, IHero targetHero);

        float GetCalculatedValue();
    }
}