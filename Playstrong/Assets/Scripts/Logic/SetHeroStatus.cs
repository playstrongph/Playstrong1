using ScriptableObjects;
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
        
        [SerializeField] [RequireInterface(typeof(IHeroStatusAsset))]
        private ScriptableObject _heroDead;
        public IHeroStatusAsset HeroDead => _heroDead as IHeroStatusAsset;



    }
}
