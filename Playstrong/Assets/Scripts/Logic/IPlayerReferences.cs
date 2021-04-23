using Interfaces;

namespace Logic
{
    public interface IPlayerReferences
    {
        IPlayerControllerEnumAsset PlayerControllerEnum { get; }
        IPlayerTypeEnumAsset PlayerTypeEnum { get; }
        IInitializePlayerHeroes InitializePlayerHeroes { get; }
    }
}