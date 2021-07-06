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

        public event HeroEvent e_PreAttack;
        public event HeroEvent e_PostAttack;


        public void PreAttack(IHero initiatorHero, IHero targetHero)
        {
            e_PreAttack?.Invoke(initiatorHero, targetHero);
        }
        
        public void PostAttack(IHero initiatorHero, IHero targetHero)
        {
            e_PostAttack?.Invoke(initiatorHero, targetHero);
        }



    }
}
