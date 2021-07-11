using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


namespace Logic
{
   

    public class HeroEvents : MonoBehaviour, IHeroEvents
    {
        public delegate void HeroEvent(IHero initiatorHero, IHero targetHero);
        
        
        public event HeroEvent EPreAttack;
        public event HeroEvent EPostAttack;
        public event HeroEvent EPreCriticalStrike;
        public event HeroEvent EPostCriticalStrike;
        public event HeroEvent EBeforeAttacking;
        public event HeroEvent EAfterAttacking;
        public event HeroEvent EBeforeCriticalStrike;
        public event HeroEvent EAfterCriticalStrike;
        
        private IHeroLogic _heroLogic;
        private List<HeroEvent> _heroEventsList = new List<HeroEvent>();
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        /// <summary>
        /// Before the target hero takes an attack
        /// </summary>
        public void PreAttack(IHero initiatorHero, IHero targetHero)
        {
            EPreAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePreAttackClients()
        {
            var clients = EPreAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPreAttack -= client as HeroEvent;
                }
        }
        
        /// <summary>
        /// After the target hero takes an attack
        /// </summary>
        public void PostAttack(IHero initiatorHero, IHero targetHero)
        {
            EPostAttack?.Invoke(initiatorHero, targetHero);
        }
        private void UnsubscribePostAttackClients()
        {
            var clients = EPostAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostAttack -= client as HeroEvent;
                }
        }
        
        public void PreCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EPreCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePreCriticalStrikeClients()
        {
            var clients = EPreCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPreCriticalStrike -= client as HeroEvent;
                }
        }

        /// <summary>
        /// After the target hero takes a critical strike
        /// </summary>
        public void PostCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EPostCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePostCriticalStrikeClients()
        {
            var clients = EPostCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostCriticalStrike -= client as HeroEvent;
                }
        }
        
        
        public void BeforeAttacking(IHero initiatorHero, IHero targetHero)
        {
            EBeforeAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeBeforeAttackingClients()
        {
            var clients = EBeforeAttacking?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeAttacking -= client as HeroEvent;
                }
        }
        
        
        public void AfterAttacking(IHero initiatorHero, IHero targetHero)
        {
            EAfterAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeAfterAttackingClients()
        {
            var clients = EAfterAttacking?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterAttacking -= client as HeroEvent;
                }
        }
        
        public void BeforeCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EBeforeCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeBeforeCriticalStrikeClients()
        {
            var clients = EBeforeCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeCriticalStrike -= client as HeroEvent;
                }
        }
        
        
        public void AfterCriticalStrike(IHero initiatorHero, IHero targetHero)
        {
            EAfterCriticalStrike?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeAfterCriticalStrikeClients()
        {
            var clients = EAfterCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterCriticalStrike -= client as HeroEvent;
                }
        }

        private void OnDisable()
        {
            UnsubscribeAllClients();           
        }
        
        /// <summary>
        /// Tried assigning each event to an event list and tried iteration removal
        /// but it did not work;  Manual removal for now.
        /// This can also be called during scene transitions in the future;
        /// </summary>
        private void UnsubscribeAllClients()
        {
            UnsubscribePreAttackClients();
            UnsubscribePostAttackClients();
            UnsubscribePreCriticalStrikeClients();
            UnsubscribePostCriticalStrikeClients();
            UnsubscribeBeforeAttackingClients();
            UnsubscribeAfterAttackingClients();
            UnsubscribeBeforeCriticalStrikeClients();
            UnsubscribeAfterCriticalStrikeClients();
        }
        
        



    }
}
