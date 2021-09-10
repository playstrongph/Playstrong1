using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IBasicActionAsset
    {
        IEnumerator StartAction(IHero thisHero, IHero targetHero);
        IEnumerator StartAction(IHero hero);
        IEnumerator StartAction(IHero hero, float value);
        IEnumerator TargetAction(IHero thisHero, IHero targetHero);
        IEnumerator TargetAction(IHero hero);
        IEnumerator TargetAction(IHero hero, float value);
    }
}