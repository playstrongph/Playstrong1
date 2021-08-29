namespace Logic
{
    public interface IHeroInabilityStatus
    {
        IHeroInabilityAsset WithHeroInabilityStatus { get; }
        IHeroInabilityAsset NoHeroInabilityStatus { get; }
    }
}