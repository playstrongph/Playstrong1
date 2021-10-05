using Interfaces;
using References;

namespace ScriptableObjects.DamageAttributeMultiple
{
    public interface ICalculatedFactorValueAsset
    {
        int DamageFactorBasis(IHero hero);

        int DamageFactorBasis(IHero thisHero, IHero targetHero);

        void SetCalculatedValue(IHero hero);

        void SetCalculatedValue(IHero thisHero, IHero targetHero);

        void SetCalculatedValue();

        float GetCalculatedValue();
        float GetCalculatedValue(IHero hero);
        float GetCalculatedValue(IHero thisHero, IHero targetHero);


        IHero OtherHeroBasis { get; set; }




    }
}