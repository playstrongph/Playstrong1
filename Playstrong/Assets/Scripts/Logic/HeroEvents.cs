using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;


namespace Logic
{
   

    public class HeroEvents : MonoBehaviour, IHeroEvents
    {
        /// <summary>
        /// Double Hero Events
        /// </summary>
        public delegate void HeroesEvent(IHero initiatorHero, IHero targetHero);
        public event HeroesEvent EPreAttack;
        public event HeroesEvent EPostAttack;
        public event HeroesEvent EPreSkillAttack;
        public event HeroesEvent EPostSkillAttack;
        public event HeroesEvent EPreCriticalStrike;
        public event HeroesEvent EPostCriticalStrike;
        public event HeroesEvent EBeforeAttacking;
        public event HeroesEvent EBeforeSkillAttacking;
        public event HeroesEvent EAfterAttacking;
        public event HeroesEvent EAfterSkillAttacking;
        public event HeroesEvent EBeforeCriticalStrike;
        public event HeroesEvent EAfterCriticalStrike;
        public event HeroesEvent EDragBasicAttack;
        public event HeroesEvent EDragSkillTarget;
        public event HeroesEvent EStartOfGame;
        
        public event HeroesEvent EBeforeCounterAttack;
        public event HeroesEvent EAfterCounterAttack;
        public event HeroesEvent EPreCounterAttack;
        public event HeroesEvent EPostCounterAttack;
        
        //NoEvent
        public event HeroesEvent ENoEvent;

        
        
        /// <summary>
        /// Single Hero Events
        /// </summary>
        
        public delegate void HeroEvent(IHero hero);
        public event HeroEvent EHeroTakesFatalDamage;
        public event HeroEvent EAfterHeroDies;
        public event HeroEvent EPostHeroDeath;
        public event HeroEvent EHeroStartTurn;
        public event HeroEvent EPreHeroStartTurn;
        public event HeroEvent EHeroEndTurn;
        public event HeroEvent EPostHeroEndTurn;
        public event HeroEvent EBeforeHeroDealsSingleAttack;
        public event HeroEvent EAfterHeroDealsSingleAttack;
        public event HeroEvent EBeforeHeroTakesSingleAttack;
        public event HeroEvent EAfterHeroTakesSingleAttack;
        
        
        
        public event HeroEvent EBeforeHeroDealsMultiAttack;
        public event HeroEvent EAfterHeroDealsMultiAttack;
        public event HeroEvent EBeforeHeroTakesMultiAttack;
        public event HeroEvent EAfterHeroTakesMultiAttack;

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
        
        public void NoEvent(IHero initiatorHero, IHero targetHero)
        {
            ENoEvent?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeNoEventClients()
        {
            var clients = ENoEvent?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    ENoEvent -= client as HeroesEvent;
                }
        }
        
        public void PreSkillAttack(IHero initiatorHero, IHero targetHero)
        {
            EPreSkillAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePreSkillAttackClients()
        {
            var clients = EPreSkillAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPreSkillAttack -= client as HeroesEvent;
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
        
        public void PostSkillAttack(IHero initiatorHero, IHero targetHero)
        {
            EPostSkillAttack?.Invoke(initiatorHero, targetHero);
        }
        private void UnsubscribePostSkillAttackClients()
        {
            var clients = EPostSkillAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostSkillAttack -= client as HeroesEvent;
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
        
        public void BeforeSkillAttacking(IHero initiatorHero, IHero targetHero)
        {
            EBeforeSkillAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeBeforeSkillAttackingClients()
        {
            var clients = EBeforeSkillAttacking?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeSkillAttacking -= client as HeroesEvent;
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
        
        public void AfterSkillAttacking(IHero initiatorHero, IHero targetHero)
        {
            EAfterSkillAttacking?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeAfterSkillAttackingClients()
        {
            var clients = EAfterSkillAttacking?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterSkillAttacking -= client as HeroesEvent;
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
        
        public void BeforeCounterAttack(IHero initiatorHero, IHero targetHero)
        {
            Debug.Log("BeforeCounterAttack: " +initiatorHero.HeroName);
            EBeforeCounterAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeBeforeCounterAttackClients()
        {
            var clients = EBeforeCounterAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeCounterAttack -= client as HeroesEvent;
                }
        }
        
        public void AfterCounterAttack(IHero initiatorHero, IHero targetHero)
        {
            Debug.Log("AfterCounterAttack: " +initiatorHero.HeroName);
            EAfterCounterAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribeAfterCounterAttackClients()
        {
            var clients = EAfterCounterAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterCounterAttack -= client as HeroesEvent;
                }
        }
        
        public void PreCounterAttack(IHero initiatorHero, IHero targetHero)
        {
            EPreCounterAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePreCounterAttackClients()
        {
            var clients = EPreCounterAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPreCounterAttack -= client as HeroesEvent;
                }
        }
        
        public void PostCounterAttack(IHero initiatorHero, IHero targetHero)
        {
            EPostCounterAttack?.Invoke(initiatorHero, targetHero);
        }
        
        private void UnsubscribePostCounterAttackClients()
        {
            var clients = EPostCounterAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostCounterAttack -= client as HeroesEvent;
                }
        }

        /// <summary>
        /// Single Hero Events
        /// </summary>
        /// <param name="hero"></param>
        
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
            Debug.Log("Post Hero Death");
            
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
        
        public void PreHeroStartTurn(IHero hero)
        {
            EPreHeroStartTurn?.Invoke(hero);
        }
        
        private void UnsubscribePreHeroStartTurnClients()
        {
            var clients = EHeroStartTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPreHeroStartTurn -= client as HeroEvent;
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
        
        public void PostHeroEndTurn(IHero hero)
        {
            EPostHeroEndTurn?.Invoke(hero);
        }
        
        private void UnsubscribePostHeroEndTurnClients()
        {
            var clients = EPostHeroEndTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EPostHeroEndTurn -= client as HeroEvent;
                }
        }
        
        public void BeforeHeroDealsSingleAttack(IHero hero)
        {
            EBeforeHeroDealsSingleAttack?.Invoke(hero);
        }
        
        private void UnsubscribeBeforeHeroDealsSingleAttackClients()
        {
            var clients = EBeforeHeroDealsSingleAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeHeroDealsSingleAttack -= client as HeroEvent;
                }
        }
        
        public void AfterHeroTakesSingleAttack(IHero hero)
        {
            EAfterHeroTakesSingleAttack?.Invoke(hero);
        }
        
        private void UnsubscribeAfterHeroTakesSingleAttackClients()
        {
            var clients = EAfterHeroTakesSingleAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterHeroTakesSingleAttack -= client as HeroEvent;
                }
        }
        
        public void BeforeHeroDealsMultiAttack(IHero hero)
        {
            EBeforeHeroDealsMultiAttack?.Invoke(hero);
        }
        
        private void UnsubscribeBeforeHeroDealsMultiAttackClients()
        {
            var clients = EBeforeHeroDealsMultiAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeHeroDealsMultiAttack -= client as HeroEvent;
                }
        }
        public void BeforeHeroTakesMultiAttack(IHero hero)
        {
            EBeforeHeroTakesMultiAttack?.Invoke(hero);
        }
        
        private void UnsubscribeBeforeHeroTakesMultiAttackClients()
        {
            var clients = EBeforeHeroTakesMultiAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeHeroTakesMultiAttack -= client as HeroEvent;
                }
        }
        
        public void AfterHeroDealsSingleAttack(IHero hero)
        {
            EAfterHeroDealsSingleAttack?.Invoke(hero);
        }
        
        private void UnsubscribeAfterHeroDealsSingleAttackClients()
        {
            var clients = EAfterHeroDealsSingleAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterHeroDealsSingleAttack -= client as HeroEvent;
                }
        }
        
        public void BeforeHeroTakesSingleAttack(IHero hero)
        {
            EBeforeHeroTakesSingleAttack?.Invoke(hero);
        }
        
        private void UnsubscribeBeforeHeroTakesSingleAttackClients()
        {
            var clients = EBeforeHeroTakesSingleAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EBeforeHeroTakesSingleAttack -= client as HeroEvent;
                }
        }
        
        public void AfterHeroDealsMultiAttack(IHero hero)
        {
            EAfterHeroDealsMultiAttack?.Invoke(hero);
        }
        
        private void UnsubscribeAfterHeroDealsMultiAttackClients()
        {
            var clients = EAfterHeroDealsMultiAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterHeroDealsMultiAttack -= client as HeroEvent;
                }
        }
        
        public void AfterHeroTakesMultiAttack(IHero hero)
        {
            EAfterHeroTakesMultiAttack?.Invoke(hero);
        }
        
        private void UnsubscribeAfterHeroTakesMultiAttackClients()
        {
            var clients = EAfterHeroTakesMultiAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EAfterHeroTakesMultiAttack -= client as HeroEvent;
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
            UnsubscribePreSkillAttackClients();
            UnsubscribePostAttackClients();
            UnsubscribePostSkillAttackClients();
            UnsubscribePreCriticalStrikeClients();
            UnsubscribePostCriticalStrikeClients();
            UnsubscribeBeforeAttackingClients();
            UnsubscribeBeforeSkillAttackingClients();
            UnsubscribeAfterAttackingClients();
            UnsubscribeAfterSkillAttackingClients();
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
            UnsubscribePostCounterAttackClients();
            UnsubscribePreCounterAttackClients();
            UnsubscribeBeforeCounterAttackClients();
            UnsubscribeAfterCounterAttackClients();
            UnsubscribePreHeroStartTurnClients();
            UnsubscribePostHeroEndTurnClients();
            UnsubscribeNoEventClients();
            UnsubscribeBeforeHeroDealsSingleAttackClients();
            UnsubscribeAfterHeroTakesSingleAttackClients();
            UnsubscribeBeforeHeroDealsMultiAttackClients();
            UnsubscribeBeforeHeroTakesMultiAttackClients();
            UnsubscribeAfterHeroDealsSingleAttackClients();
            UnsubscribeBeforeHeroTakesSingleAttackClients();
            UnsubscribeAfterHeroDealsMultiAttackClients();
            UnsubscribeAfterHeroTakesMultiAttackClients();


        }
        
        



    }
}
