using Interfaces;

namespace ScriptableObjects.CalculatedFactorValue
{
    public interface ICalculatedFactorValueAsset
    {
        int DamageFactorBasis();
        int DamageFactorBasis(IHero hero);
        int DamageFactorBasis(IHero thisHero, IHero targetHero);

        void SetCalculatedValue();
        void SetCalculatedValue(IHero hero);
        void SetCalculatedValue(IHero thisHero, IHero targetHero);
        

        float GetCalculatedValue();
        float GetCalculatedValue(IHero hero);
        float GetCalculatedValue(IHero thisHero, IHero targetHero);


        IHero OtherHeroBasis { get; set; }

        IHero SetHeroBasis(IHero hero);




    }
}