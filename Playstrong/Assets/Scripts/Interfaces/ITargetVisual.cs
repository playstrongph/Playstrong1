using UnityEngine;

namespace Interfaces
{
    public interface ITargetVisual
    {
        Canvas TargetCanvas { get; }
        GameObject TargetCrossHair { get; }
        GameObject TargetTriangle { get; }
        LineRenderer TargetLineR { get; }
    }
}