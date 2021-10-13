using System.Collections.Generic;

namespace Logic
{
    public interface IHeroUniqueEffects
    {
        List<IHeroStatusEffect> UniqueEffects { get; }
        void AddToList(IHeroStatusEffect uniqueEffect);
        void RemoveFromList(IHeroStatusEffect uniqueEffect);
    }
}