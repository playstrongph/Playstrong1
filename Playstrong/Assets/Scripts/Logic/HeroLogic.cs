using System;
using System.Runtime.Remoting.Messaging;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    
    /// <summary>
    /// HeroLogic Reference Scripts
    /// Objects are set in the Inspector
    /// </summary>
    public class HeroLogic : MonoBehaviour, IHeroLogic
    {
        [SerializeField] [RequireInterface(typeof(IHeroPrefab))]
        private Object _heroPrefab;

        public IHeroPrefab HeroPrefab
        {
            get => _heroPrefab as IHeroPrefab;
           
        }
        
        [SerializeField]
        [RequireInterface(typeof(IHeroAttributes))]
        private Object _heroAttributes;

        public IHeroAttributes HeroAttributes
        {
            get => _heroAttributes as IHeroAttributes;
           
        }

        [SerializeField]
        [RequireInterface(typeof(ILoadHeroAttributes))]
        private Object _loadHeroAttributes;

        public ILoadHeroAttributes LoadHeroAttributes
        {
            get => _loadHeroAttributes as ILoadHeroAttributes;
        
        }



    }
}
