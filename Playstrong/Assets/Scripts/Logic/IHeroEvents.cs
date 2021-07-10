using Interfaces;

namespace Logic
{
    public interface IHeroEvents
    {
        
      
        event HeroEvents.HeroEvent EPreAttack;
        event HeroEvents.HeroEvent EPostAttack;
        
        event HeroEvents.HeroEvent EPreCriticalStrike;
        event HeroEvents.HeroEvent EPostCriticalStrike;
        
        event HeroEvents.HeroEvent EBeforeAttacking;
        
        event HeroEvents.HeroEvent EAfterAttacking;
        
        event HeroEvents.HeroEvent EBeforeCriticalStrike;
        
        event HeroEvents.HeroEvent EAfterCriticalStrike;
        
        
        
        void PreAttack(IHero initiatorHero, IHero targetHero);
        void PostAttack(IHero initiatorHero, IHero targetHero);
        
        void PreCriticalStrike(IHero initiatorHero, IHero targetHero);
        void PostCriticalStrike(IHero initiatorHero, IHero targetHero);

        void BeforeAttacking(IHero initiatorHero, IHero targetHero);

        void AfterAttacking(IHero initiatorHero, IHero targetHero);
        
        void BeforeCriticalStrike(IHero initiatorHero, IHero targetHero);

        void AfterCriticalStrike(IHero initiatorHero, IHero targetHero);
    }
}