using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public interface ITargetVisualReferences
    {
        Canvas TargetCanvas { get; }
        Image TargetCrossHair { get; }
        Image TargetTriangle { get; }
        LineRenderer TargetLineR { get; }
    }
}