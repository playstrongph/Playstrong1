using System.Collections;

namespace Logic
{
    public interface IHeroInabilityAsset
    {
        IEnumerator StatusAction(ITurnController turnController);
    }
}