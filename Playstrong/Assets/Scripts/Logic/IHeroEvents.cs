using Interfaces;

namespace Logic
{
    public interface IHeroEvents
    {
        event HeroEvents.HeroEvent e_PreAttack;
        event HeroEvents.HeroEvent e_PostAttack;
        void PreAttack(IHero initiatorHero, IHero targetHero);
        void PostAttack(IHero initiatorHero, IHero targetHero);
    }
}