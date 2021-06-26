using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;

namespace Interfaces
{
    public interface IHeroLogic
    {

        IHeroStatusAsset HeroStatus { get; set; }

        ITargetStatus TargetStatus { get; set; }

        IHero Hero { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

        IHeroTimer HeroTimer { get; }

        IBasicAttack BasicAttack { get; }

        ITakeDamage TakeDamage { get; }

        IEndHeroTurn EndHeroTurn { get; }

        ISetHeroAttack SetHeroAttack { get; }





    }
}