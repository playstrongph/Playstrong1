using System;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class SetHeroStatus : MonoBehaviour, ISetHeroStatus
    {
        [SerializeField] [RequireInterface(typeof(IHeroStatusAsset))]
        private ScriptableObject _heroActive;
        public IHeroStatusAsset HeroActive => _heroActive as IHeroStatusAsset;
        
        [SerializeField] [RequireInterface(typeof(IHeroStatusAsset))]
        private ScriptableObject _heroInactive;
        public IHeroStatusAsset HeroInactive => _heroInactive as IHeroStatusAsset;
        
       

        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
            
            HeroActive.InitializeTurnController(_turnController);
            HeroInactive.InitializeTurnController(_turnController);
       
            
        }
    }
}
