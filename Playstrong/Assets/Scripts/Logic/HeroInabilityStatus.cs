using System;
using Interfaces;
using ScriptableObjects.HeroLivingStatus;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroInabilityStatus : MonoBehaviour, IHeroInabilityStatus
    {

        [SerializeField]
        private ScriptableObject withHeroInabilityStatus;
        public IHeroInabilityAsset WithHeroInabilityStatus => withHeroInabilityStatus as IHeroInabilityAsset;
        
        [SerializeField]
        private ScriptableObject noHeroInabilityStatus;
        public IHeroInabilityAsset NoHeroInabilityStatus => noHeroInabilityStatus as IHeroInabilityAsset;

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
    }
}
