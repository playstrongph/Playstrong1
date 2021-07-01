using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IHeroAction
    {
        IEnumerator TargetHero(IHero targetHero);
        
        IEnumerator HeroAction(IHero targetHero);
    }
}
