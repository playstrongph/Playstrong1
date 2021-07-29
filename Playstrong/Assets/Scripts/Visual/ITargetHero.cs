using Interfaces;
using Logic;
using UnityEngine;

namespace Visual
{
    public interface ITargetHero
    {
        IHero Hero { get; }

        ITargetPreview HeroPreview { get; }

        IDragHeroAttack DragHeroAttack { get; }

        IGetAttackTargets GetAttackTargets { get; }

        BoxCollider HeroBoxCollider { get; }

        ITargetVisual TargetVisual { get; }
    }
}