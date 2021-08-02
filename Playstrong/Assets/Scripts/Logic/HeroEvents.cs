using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


namespace Logic
{
   

    public class HeroEvents : MonoBehaviour, IHeroEvents
    {
        public delegate void HeroesEvent(IHero initiatorHero, IHero targetHero);
        
        public delegate void HeroEvent(IHero hero);
        
        public event HeroesEvent EPreAttack;
        public event HeroesEvent EPostAttack;
        public event HeroesEvent EPreCriticalStrike;
        public event HeroesEvent EPostCriticalStrike;
        public event HeroesEvent EBeforeAttacking;
        public event HeroesEvent EAfterAttacking;
        public event HeroesEvent EBeforeCriticalStrike;
        public event HeroesEvent EAfterCriticalStrike;
        public event HeroesEvent EDragBasicAttack;
        public event HeroesEvent EDragSkillTarget;
        public event HeroesEvent EStartOfGame;

        public event HeroEvent EHeroTakesFatalDamage;
        
        public event HeroEvent EAfterHeroDies;
        
        public event HeroEvent EPostHeroDeath;

        public event HeroEvent EHeroStartTurn;
        
        public event HeroEvent EHeroEndTurn;
        
        
        private IHeroLogic _heroLogic;
        private List<HeroesEvent> _heroEventsList = new List<HeroesEvent>();
        
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
                    EPreAttack -= client as HeroesEvent;
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
                    EPostAttack -= client as HeroesEvent;
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
                    EPreCriticalStrike -= client as HeroesEvent;
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
                    EPostCriticalStrike -= client as HeroesEvent;
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
                    EBeforeAttacking -= client as HeroesEvent;
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
                    EAfterAttacking -= client as HeroesEvent;
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
                    EBeforeCriticalStrike -= client as HeroesEvent;
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
                    EAfterCriticalStrike -= client as HeroesEvent;
                }
        }
        
        public void DragBasicAttack(IHero initiatorHero, IHero targetHero)
        {
            EDragBasicAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeDragBasicAttackClients()
        {
            var clients = EDragBasicAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EDragBasicAttack -= client as HeroesEvent;
                }
        }
        
        public void DragSkillTarget(IHero initiatorHero, IHero targetHero)
        {
            EDragSkillTarget?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeDragSkillTargetClients()
        {
            var clients = EDragSkillTarget?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EDragSkillTarget -= client as HeroesEvent;
                }
        }
        
        public void StartOfGame(IHero initiatorHero, IHero targetHero)
        {
            EStartOfGame?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeStartOfGameClients()
        {
            var clients = EStartOfGame?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EStartOfGame -= client as HeroesEvent;
                }
        }
        
        public void HeroTakesFatalDamage(IHero hero)
        {
            EHeroTakesFatalDamage?.Invoke(hero);
        }
        
        private void UnsubscribeHeroTakesFatalDamageClients()
        {
            var clients = EHeroTakesFatalDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EHeroTakesFatalDamage -= client as HeroEvent;
                }
        }
        
        public void AfterHeroDies(IHero hero)
        {
            EAfterHeroDies?.Invoke(hero);
        }
        
        private void UnsubscribeAfterHeroDiesClients()
        {
            var clients = EAfterHeroDies?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterHeroDies -= client as HeroEvent;
                }
        }
        
        /// <summary>
        /// Called after AfterHeroDies.  This event calls any revive effect for the hero
        /// </summary>
        public void PostHeroDeath(IHero hero)
        {
            EPostHeroDeath?.Invoke(hero);
        }
        
        private void UnsubscribePostHeroDeathClients()
        {
            var clients = EPostHeroDeath?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostHeroDeath -= client as HeroEvent;
                }
        }
        
        public void HeroStartTurn(IHero hero)
        {
            EHeroStartTurn?.Invoke(hero);
        }
        
        private void UnsubscribeHeroStartTurnClients()
        {
            var clients = EHeroStartTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EHeroStartTurn -= client as HeroEvent;
                }
        }
        
        public void HeroEndTurn(IHero hero)
        {
            EHeroEndTurn?.Invoke(hero);
        }
        
        private void UnsubscribeHeroEndTurnClients()
        {
            var clients = EHeroEndTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EHeroEndTurn -= client as HeroEvent;
                }
        }

        private void OnDestroy()
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
            UnsubscribeDragBasicAttackClients();
            UnsubscribeDragSkillTargetClients();
            UnsubscribeStartOfGameClients();
            UnsubscribeHeroTakesFatalDamageClients();
            UnsubscribeAfterHeroDiesClients();
            UnsubscribePostHeroDeathClients();
            UnsubscribeHeroStartTurnClients();
            UnsubscribeHeroEndTurnClients();
        }
        
        



    }
}
