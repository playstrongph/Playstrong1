﻿using System.Collections.Generic;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IHeroBuffEffects
    {
        List<IBuffEffectAsset> HeroBuffs { get; }
    }
}