using Interfaces;

namespace Logic
{
    public interface IHeroTimer
    {
        float TimerValue { get; set; }
        float TimerValuePercentage { get; set; }

        IHeroLogic HeroLogic { get; }

        void ResetHeroTimer();

        void UpdateHeroTimer(ITurnController turnController);
        
        void SetHeroTimerValue(ITurnController turnController, int energyValue);
    }
}