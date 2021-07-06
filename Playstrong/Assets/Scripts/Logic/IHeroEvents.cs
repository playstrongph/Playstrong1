using Interfaces;

namespace Logic
{
    public interface IHeroEvents
    {
        event HeroEvents.HeroEvent EPreAttack;
        event HeroEvents.HeroEvent EPostAttack;
        
        event HeroEvents.HeroEvent EBeforeAttack;
        
        event HeroEvents.HeroEvent EAfterAttack;
        
        
        
        void PreAttack(IHero initiatorHero, IHero targetHero);
        void PostAttack(IHero initiatorHero, IHero targetHero);

        void BeforeAttack(IHero initiatorHero, IHero targetHero);

        void AfterAttack(IHero initiatorHero, IHero targetHero);
    }
}