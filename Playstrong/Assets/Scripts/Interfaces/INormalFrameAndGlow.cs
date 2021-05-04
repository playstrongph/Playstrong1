using UnityEngine;

namespace Interfaces
{
    public interface INormalFrameAndGlow
    {
        GameObject EnemyGlowFrame { get; }
        GameObject AllyGlowFrame { get; }
        GameObject ActionGlowFrame { get; }
    }
}