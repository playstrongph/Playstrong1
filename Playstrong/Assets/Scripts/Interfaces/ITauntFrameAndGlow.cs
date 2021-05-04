using UnityEngine;

namespace Interfaces
{
    public interface ITauntFrameAndGlow
    {
        GameObject AllyGlowFrame { get; }
        GameObject EnemyGlowFrame { get; }
        GameObject ActionGlowFrame { get; }
        GameObject Frame { get; }
    }
}