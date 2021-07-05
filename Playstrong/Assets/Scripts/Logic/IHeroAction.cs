using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IHeroAction
    {
        IEnumerator ActionTarget(IHero thisHero, IHero targetHero);
        
        IEnumerator StartAction(IHero thisHero, IHero targetHero);
    }
}
