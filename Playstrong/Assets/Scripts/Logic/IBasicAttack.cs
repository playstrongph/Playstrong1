using System.Collections;
using Interfaces;

namespace Logic
{
    public interface IBasicAttack
    {
        IHeroAction AttackAction { get; }
    }
}