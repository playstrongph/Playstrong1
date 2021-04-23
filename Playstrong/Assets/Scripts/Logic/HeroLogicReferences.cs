using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class HeroLogicReferences : MonoBehaviour, IHeroLogicReferences
    {
        private IHeroAttributes _heroAttributes;
        public IHeroAttributes HeroAttributes => _heroAttributes;

        private ILoadHeroAttributes _loadHeroAttributes;
        public ILoadHeroAttributes LoadHeroAttributes => _loadHeroAttributes; 

        private void Awake()
        {
            _heroAttributes = GetComponent<IHeroAttributes>();
            _loadHeroAttributes = GetComponent<ILoadHeroAttributes>();
        }
        
        
    }
}
