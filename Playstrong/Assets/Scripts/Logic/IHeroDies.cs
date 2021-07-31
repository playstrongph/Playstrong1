using System.Collections;
using Interfaces;
using Visual.Animation;

namespace Logic
{
    public interface IHeroDies
    {
        IEnumerator CheckHeroDeath(IHero hero);
    }
}