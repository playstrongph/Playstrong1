using System.Collections;
using Interfaces;

namespace ScriptableObjects.StandardActions
{
    public interface IStandardActionAsset
    {
        IEnumerator StartAction(IHero thisHero, IHero targetHero);

        /// <summary>
        /// StartAction for StatusEffects
        /// </summary>
        IEnumerator StartAction(IHero targetHero, float value);

        /// <summary>
        /// Should only be accessed by AliveLivingHero.DoHeroAction
        /// </summary>
        IEnumerator TargetAction(IHero thisHero, IHero targetHero);

        IEnumerator TargetAction(IHero targetHero, float value);
    }
}