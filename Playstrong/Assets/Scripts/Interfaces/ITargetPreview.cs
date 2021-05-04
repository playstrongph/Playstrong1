namespace Interfaces
{
    public interface ITargetPreview
    {
        void HidePreview();

        ITargetVisual TargetVisual { get; }

    }
}