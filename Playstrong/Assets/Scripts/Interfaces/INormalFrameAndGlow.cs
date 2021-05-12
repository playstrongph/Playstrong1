﻿using UnityEngine;

namespace Interfaces
{
    public interface INormalFrameAndGlow
    {
        GameObject AllyGlowFrame { get; }
        GameObject EnemyGlowFrame { get; }
        GameObject ActionGlowFrame { get; }
        GameObject Frame { get; }
    }
}