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
        
        public event HeroEvent EBeforeAttack;
        
        public event HeroEvent EAfterAttack;
        
        
        /// <summary>
        /// Before the initiator hero deals an attack
        /// </summary>
        public void PreAttack(IHero initiatorHero, IHero targetHero)
        {
            EPreAttack?.Invoke(initiatorHero, targetHero);
        }
        
        /// <summary>
        /// After the initiator hero deals an attack
        /// </summary>
        public void PostAttack(IHero initiatorHero, IHero targetHero)
        {
            EPostAttack?.Invoke(initiatorHero, targetHero);
        }
        
        /// <summary>
        /// Before the target hero receives an attack
        /// </summary>
        public void BeforeAttack(IHero initiatorHero, IHero targetHero)
        {
            EBeforeAttack?.Invoke(initiatorHero, targetHero);
        }
        
        /// <summary>
        /// After the target hero receives an attack
        /// </summary>
        public void AfterAttack(IHero initiatorHero, IHero targetHero)
        {
            EAfterAttack?.Invoke(initiatorHero, targetHero);
        }



    }
}
