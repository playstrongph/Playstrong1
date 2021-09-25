using Logic;
using ScriptableObjects;
using ScriptableObjects.HeroLivingStatus;
using ScriptableObjects.Others;

namespace Interfaces
{
    public interface IHeroLogic
    {

        IHeroStatusAsset HeroStatus { get; set; }

        ITargetStatus TargetStatus { get; set; }

        IHeroLivingStatusAsset HeroLivingStatus { get; set; }

        IHeroInabilityAsset HeroInabilityStatus { get; set; }

        IHero Hero { get; }
        IHeroAttributes HeroAttributes { get;}

        ILoadHeroAttributes LoadHeroAttributes { get; }

        IHeroTimer HeroTimer { get; }

        IBasicAttack BasicAttack { get; }

        ITakeDamage TakeDamage { get; }

        IEndHeroTurn EndHeroTurn { get; }

        ISetHeroAttack SetHeroAttack { get; }

        ISetHeroSpeed SetHeroSpeed { get; }

        ISetHeroHealth SetHeroHealth { get; }

        ISetHeroArmor SetHeroArmor { get; }

        ISetHeroEnergy SetHeroEnergy { get; }

        IHeroEvents HeroEvents { get; }

        ISkillAttributes BasicAttackSkillAttributes { get; }

        IDealDamage DealDamage { get; }

        IHeroDies HeroDies { get; }

        IOtherAttributes OtherAttributes { get; }

        ICounterAttack CounterAttack { get; }

        IHeroInabilityStatus HeroInabilityStatusAssets { get; }

        IDealDamageTest DealDamageTest { get; }

        ITakeDamageTest TakeDamageTest { get; }





    }
}