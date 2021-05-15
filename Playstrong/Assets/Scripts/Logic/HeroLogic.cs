using System;
using System.Runtime.Remoting.Messaging;
using Interfaces;
using ScriptableObjects;
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

       [SerializeField] [RequireInterface(typeof(IHeroStatusAsset))]
        private ScriptableObject _heroStatus;

        public IHeroStatusAsset HeroStatus
        {
            get { return _heroStatus as IHeroStatusAsset;}
            set { _heroStatus = value as ScriptableObject;}
        }
        
        [SerializeField] [RequireInterface(typeof(IHero))]
        private Object _hero;

        public IHero Hero
        {
            get => _hero as IHero;
           
        }

        [SerializeField]
        [RequireInterface(typeof(IHeroAttributes))]
        private Object _heroAttributes;

        public IHeroAttributes HeroAttributes
        {
            get => _heroAttributes as IHeroAttributes;
           
        }

        [SerializeField] [RequireInterface(typeof(IHeroTimer))]
        private Object _heroTimer;

        public IHeroTimer HeroTimer => _heroTimer as IHeroTimer;

        [SerializeField]
        [RequireInterface(typeof(ILoadHeroAttributes))]
        private Object _loadHeroAttributes;

        public ILoadHeroAttributes LoadHeroAttributes => _loadHeroAttributes as ILoadHeroAttributes;

       

        
    }
}
