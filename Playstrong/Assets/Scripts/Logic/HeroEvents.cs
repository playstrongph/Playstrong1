using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
   

    public class HeroEvents : MonoBehaviour, IHeroEvents
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public delegate void HeroEvent(IHero initiatorHero, IHero targetHero);
        
        public event HeroEvent EPreAttack;
        public event HeroEvent EPostAttack;
        
        public event HeroEvent EPreCriticalStrike;
        
        public event HeroEvent EPostCriticalStrike;
        
        public event HeroEvent EBeforeAttacking;
        
        public event HeroEvent EAfterAttacking;
        
        public event HeroEvent EBeforeCriticalStrike;
        
        public event HeroEvent EAfterCriticalStrike;
        
        
        
        
        /// <summary>
        /// Before the target hero takes an attack
        /// </summary>
        public void PreAttack(IHero initiatorHero, IHero targetHero)
        {
            EPreAttack?.Invoke(initiatorHero, targetHero);
        }
        
        /// <summary>
        /// After the target hero takes an attack
        /// </summary>
        public void PostAttack(IHero initiatorHero, IHero targetHero)
        {
            EPostAttack?.Invoke(initiatorHero, targetHero);
        }
        
        public void PreCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EPreCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        /// <summary>
        /// After the target hero takes a critical strike
        /// </summary>
        public void PostCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EPostCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        
        public void BeforeAttacking(IHero initiatorHero, IHero targetHero)
        {
            EBeforeAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        
        public void AfterAttacking(IHero initiatorHero, IHero targetHero)
        {
            EAfterAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        public void BeforeCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EBeforeCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        
        public void AfterCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EAfterCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        



    }
}
