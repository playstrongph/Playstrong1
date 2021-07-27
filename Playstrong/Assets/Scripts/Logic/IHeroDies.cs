using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IHeroDies
    {
        IEnumerator CheckHeroDeath(IHero hero);
    }
}