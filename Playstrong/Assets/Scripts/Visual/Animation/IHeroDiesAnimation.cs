using System.Collections;
using Interfaces;

namespace Visual.Animation
{
    public interface IHeroDiesAnimation
    {
        IEnumerator StartAnimation(IHero hero);
    }
}