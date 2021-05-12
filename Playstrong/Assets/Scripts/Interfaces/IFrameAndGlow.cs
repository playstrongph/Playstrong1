using UnityEngine;

namespace Interfaces
{
    public interface IFrameAndGlow
    {
        GameObject AllyGlowFrame { get; }
        GameObject EnemyGlowFrame { get; }
        GameObject ActionGlowFrame { get; }
        GameObject Frame { get; }
    }
}