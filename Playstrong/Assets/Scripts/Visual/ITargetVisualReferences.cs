using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public interface ITargetVisualReferences
    {
        Canvas TargetCanvas { get; }
        GameObject TargetCrossHair { get; }
        GameObject TargetTriangle { get; }
        LineRenderer TargetLineR { get; }
    }
}