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
    public class HeroLogicReferences : MonoBehaviour, IHeroLogicReferences
    {
        [SerializeField] [RequireInterface(typeof(IHeroObjectReferences))]
        private Object _heroObjectReferences;

        public IHeroObjectReferences HeroObjectReferences
        {
            get => _heroObjectReferences as IHeroObjectReferences;
            set => _heroObjectReferences = value as Object;
        }
        
        [SerializeField]
        [RequireInterface(typeof(IHeroAttributes))]
        private Object _heroAttributes;

        public IHeroAttributes HeroAttributes
        {
            get => _heroAttributes as IHeroAttributes;
            set => _heroAttributes = value as Object;
        }

        [SerializeField]
        [RequireInterface(typeof(ILoadHeroAttributes))]
        private Object _loadHeroAttributes;

        public ILoadHeroAttributes LoadHeroAttributes
        {
            get => _loadHeroAttributes as ILoadHeroAttributes;
            set => _loadHeroAttributes = value as Object;
        }



    }
}
