namespace Logic
{
    public interface ITargetStatusOptions
    {

        ITargetStatus TauntTarget { get; }

        ITargetStatus NormalTarget { get; }

        ITargetStatus StealthTarget { get; }

    }
}