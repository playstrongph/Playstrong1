using System.Collections;
using Interfaces;
using References;

namespace ScriptableObjects.StandardActions
{
    public interface IStandardActionAsset
    {
        IEnumerator RegisterStandardAction(IHero hero);
        IEnumerator UnregisterStandardAction(IHero hero);
        IEnumerator RegisterStandardAction(ISkill skill);
        IEnumerator UnregisterStandardAction(ISkill skill);
        void StartAction(IHero targetHero);
        void StartAction(IHero thisHero, IHero targetHero);
    }
}