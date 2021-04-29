using UnityEngine;

namespace Interfaces
{
    public interface ITargetVisualReferences
    {
        Canvas TargetCanvas { get; }
        GameObject TargetCrossHair { get; }
        GameObject TargetTriangle { get; }
        LineRenderer TargetLineR { get; }
    }
}