using ScriptableObjects;
using ScriptableObjects.Others;

namespace Logic
{
    public interface ISetHeroStatus
    {
        IHeroStatusAsset HeroActive { get; }
        IHeroStatusAsset HeroInactive { get; }
      

        
    }
}