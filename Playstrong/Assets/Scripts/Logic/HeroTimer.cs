using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroTimer : MonoBehaviour, IHeroTimer
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroLogic))]
        private Object _heroLogic;
        public IHeroLogic HeroLogic => _heroLogic as IHeroLogic;
        
        [SerializeField] 
        private float _timerValue;

        public float TimerValue
        {
            get => _timerValue;
            set => _timerValue = value;
        }

        [SerializeField]
        private float _timerValuePercentage;

        public float TimerValuePercentage
        {
            get => _timerValuePercentage;
            set => _timerValuePercentage = value;
        }

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>() as Object;
        }
    }
}
