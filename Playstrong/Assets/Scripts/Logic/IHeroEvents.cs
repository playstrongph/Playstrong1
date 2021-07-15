﻿using Interfaces;

namespace Logic
{
    public interface IHeroEvents
    {
        
      
        event HeroEvents.HeroesEvent EPreAttack;
        event HeroEvents.HeroesEvent EPostAttack;
        
        event HeroEvents.HeroesEvent EPreCriticalStrike;
        event HeroEvents.HeroesEvent EPostCriticalStrike;
        
        event HeroEvents.HeroesEvent EBeforeAttacking;
        
        event HeroEvents.HeroesEvent EAfterAttacking;
        
        event HeroEvents.HeroesEvent EBeforeCriticalStrike;
        
        event HeroEvents.HeroesEvent EAfterCriticalStrike;
        
        event HeroEvents.HeroesEvent EDragBasicAttack;
        
        event HeroEvents.HeroesEvent EDragSkillTarget;
        
        event HeroEvents.HeroesEvent EStartOfGame;
        
        
        
        void PreAttack(IHero initiatorHero, IHero targetHero);
        void PostAttack(IHero initiatorHero, IHero targetHero);
        
        void PreCriticalStrike(IHero initiatorHero, IHero targetHero);
        void PostCriticalStrike(IHero initiatorHero, IHero targetHero);

        void BeforeAttacking(IHero initiatorHero, IHero targetHero);

        void AfterAttacking(IHero initiatorHero, IHero targetHero);
        
        void BeforeCriticalStrike(IHero initiatorHero, IHero targetHero);

        void AfterCriticalStrike(IHero initiatorHero, IHero targetHero);

        void DragBasicAttack(IHero initiatorHero, IHero targetHero);
        
        void DragSkillTarget(IHero initiatorHero, IHero targetHero);
        
        void StartOfGame(IHero initiatorHero, IHero targetHero);
    }
}