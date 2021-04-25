using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroesListReference : MonoBehaviour, IHeroesListReference
    {
        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _livingHeroes;
        public IHeroesList LivingHeroes => _livingHeroes as IHeroesList;
        
        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _deadHeroes;
        public IHeroesList DeadHeroes => _deadHeroes as IHeroesList;
        
        



    }
}
