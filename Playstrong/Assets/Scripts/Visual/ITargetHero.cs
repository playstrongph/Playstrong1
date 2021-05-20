﻿using Interfaces;
using Logic;

namespace Visual
{
    public interface ITargetHero
    {
        IHero Hero { get; }

        ITargetPreview HeroPreview { get; }

        IDragHeroAttack DragHeroAttack { get; }

        IBasicAttackTargets BasicAttackTargets { get; }
    }
}