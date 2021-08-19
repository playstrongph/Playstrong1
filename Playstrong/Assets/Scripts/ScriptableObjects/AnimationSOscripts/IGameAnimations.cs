using System.Collections;
using Interfaces;

namespace ScriptableObjects.AnimationSOscripts
{
    public interface IGameAnimations
    {
        IEnumerator StartAnimation(IHero hero);
    }
}