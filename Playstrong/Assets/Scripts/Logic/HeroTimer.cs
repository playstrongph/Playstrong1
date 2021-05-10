using UnityEngine;

namespace Logic
{
    public class HeroTimer : MonoBehaviour, IHeroTimer
    {
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

    }
}
