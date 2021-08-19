using System.Collections;
using Interfaces;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroAction
    {
        IEnumerator ActionTarget(IHero thisHero, IHero targetHero);
        
        IEnumerator StartAction(IHero thisHero, IHero targetHero);

        IEnumerator StartAction(IHero targetHero, float value);

        IEnumerator ActionTarget(IHero targetHero, float value);
    }
}
