using Interfaces;

namespace Logic
{
    public interface IHeroEvents
    {
        event HeroEvents.HeroesEvent EPreAttack;
        event HeroEvents.HeroesEvent EPreSkillAttack;
        event HeroEvents.HeroesEvent EPostAttack;
        event HeroEvents.HeroesEvent EPostSkillAttack;
        
        event HeroEvents.HeroesEvent EPreCriticalStrike;
        event HeroEvents.HeroesEvent EPostCriticalStrike;
        event HeroEvents.HeroesEvent EBeforeAttacking;
        
        event HeroEvents.HeroesEvent EBeforeSkillAttacking;
        event HeroEvents.HeroesEvent EAfterAttacking;
        event HeroEvents.HeroesEvent EAfterSkillAttacking;
        
        event HeroEvents.HeroesEvent EBeforeCounterAttack;
        
        event HeroEvents.HeroesEvent EAfterCounterAttack;
        
        event HeroEvents.HeroesEvent EPreCounterAttack;
        event HeroEvents.HeroesEvent EPostCounterAttack;
        
        event HeroEvents.HeroesEvent EBeforeCriticalStrike;
        
        event HeroEvents.HeroesEvent EAfterCriticalStrike;
        
        event HeroEvents.HeroesEvent EDragBasicAttack;
        
        event HeroEvents.HeroesEvent EDragSkillTarget;
        
        event HeroEvents.HeroesEvent EStartOfGame;
        
        event HeroEvents.HeroesEvent ENoEvent;

        //Single Hero Events
        event HeroEvents.HeroEvent EHeroTakesFatalDamage;
        event HeroEvents.HeroEvent EAfterHeroDies;
        event HeroEvents.HeroEvent EPostHeroDeath;
        event HeroEvents.HeroEvent EHeroStartTurn;
        event HeroEvents.HeroEvent EPreHeroStartTurn;
        event HeroEvents.HeroEvent EHeroEndTurn;
        event HeroEvents.HeroEvent EPostHeroEndTurn;
        event HeroEvents.HeroEvent EBeforeHeroDealsSingleAttack;
        event HeroEvents.HeroEvent EBeforeHeroTakesSingleAttack;
        event HeroEvents.HeroEvent EAfterHeroTakesSingleAttack;
        event HeroEvents.HeroEvent EAfterHeroDealsSingleAttack;
        event HeroEvents.HeroEvent EBeforeHeroDealsMultiAttack;
        event HeroEvents.HeroEvent EBeforeHeroTakesMultiAttack;
        event HeroEvents.HeroEvent EAfterHeroDealsMultiAttack;
        event HeroEvents.HeroEvent EAfterHeroTakesMultiAttack;
        
        //Deal and Take Damage events
        event HeroEvents.HeroEvent EBeforeHeroTakesSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroTakesSkillDamage;
        event HeroEvents.HeroEvent EBeforeHeroDealsSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroDealsSkillDamage;
        event HeroEvents.HeroEvent EBeforeHeroTakesNonSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroTakesNonSkillDamage;
        event HeroEvents.HeroEvent EBeforeHeroDealsNonSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroDealsNonSkillDamage;

        void PreAttack(IHero initiatorHero, IHero targetHero);
        void PreSkillAttack(IHero initiatorHero, IHero targetHero);
        void PostAttack(IHero initiatorHero, IHero targetHero);
        void PostSkillAttack(IHero initiatorHero, IHero targetHero);
        void BeforeCounterAttack(IHero initiatorHero, IHero targetHero);
        void AfterCounterAttack(IHero initiatorHero, IHero targetHero);
        void PreCounterAttack(IHero initiatorHero, IHero targetHero);
        void PostCounterAttack(IHero initiatorHero, IHero targetHero);
        void PreCriticalStrike(IHero initiatorHero, IHero targetHero);
        void PostCriticalStrike(IHero initiatorHero, IHero targetHero);
        void BeforeAttacking(IHero initiatorHero, IHero targetHero);
        void BeforeSkillAttacking(IHero initiatorHero, IHero targetHero);
        void AfterAttacking(IHero initiatorHero, IHero targetHero);
        void AfterSkillAttacking(IHero initiatorHero, IHero targetHero);
        void BeforeCriticalStrike(IHero initiatorHero, IHero targetHero);
        void AfterCriticalStrike(IHero initiatorHero, IHero targetHero);
        void DragBasicAttack(IHero initiatorHero, IHero targetHero);
        void DragSkillTarget(IHero initiatorHero, IHero targetHero);
        void StartOfGame(IHero initiatorHero, IHero targetHero);

        //Single Hero Events
        void HeroTakesFatalDamage(IHero hero);
        void AfterHeroDies(IHero hero);
        void PostHeroDeath(IHero hero);
        void HeroStartTurn(IHero hero);
        void PreHeroStartTurn(IHero hero);
        void HeroEndTurn(IHero hero);
        void PostHeroEndTurn(IHero hero);
        void BeforeHeroDealsSingleAttack(IHero hero);
        void AfterHeroTakesSingleAttack(IHero hero);
        void BeforeHeroDealsMultiAttack(IHero hero);
        void BeforeHeroTakesMultiAttack(IHero hero);
        void AfterHeroDealsSingleAttack(IHero hero);
        void BeforeHeroTakesSingleAttack(IHero hero);
        void AfterHeroDealsMultiAttack(IHero hero);
        void AfterHeroTakesMultiAttack(IHero hero);
        void BeforeHeroTakesSkillDamage(IHero hero);
        void AfterHeroTakesSkillDamage(IHero hero);
        void BeforeHeroDealsSkillDamage(IHero hero);
        void AfterHeroDealsSkillDamage(IHero hero);
        void BeforeHeroTakesNonSkillDamage(IHero hero);
        void AfterHeroTakesNonSkillDamage(IHero hero);
        void BeforeHeroDealsNonSkillDamage(IHero hero);
        void AfterHeroDealsNonSkillDamage(IHero hero);

    }
}