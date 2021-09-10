using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IStandardConditionAsset
    {
        IEnumerator StartAction(IHero hero);
        IEnumerator StartAction(IHero thisHero, IHero targetHero);
        IEnumerator StartAction(IHero hero, float value);

        void RegisterStartAction(IHero hero);
        void RegisterStartAction(IHero thisHero, IHero targetHero);
        void RegisterStartAction(IHero hero, float value);
    }
}