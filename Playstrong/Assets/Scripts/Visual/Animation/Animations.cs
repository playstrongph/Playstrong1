using System.Collections;
using Interfaces;

namespace Visual.Animation
{
    public interface IAnimations
    {
        IEnumerator StartAnimation(IHero hero);
    }
}