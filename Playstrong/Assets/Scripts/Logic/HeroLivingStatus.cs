using System;
using Interfaces;
using ScriptableObjects.HeroLivingStatus;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroLivingStatus : MonoBehaviour, IHeroLivingStatus
    {

        [SerializeField]
        [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private Object _heroAliveStatus;
        public IHeroLivingStatusAsset HeroAliveStatus => _heroAliveStatus as IHeroLivingStatusAsset;
        
        [SerializeField]
        [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private Object _heroDeadStatus;
        public IHeroLivingStatusAsset HeroDeadStatus => _heroDeadStatus as IHeroLivingStatusAsset;

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
    }
}
