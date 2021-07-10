using Interfaces;

namespace Logic
{
    public interface IInitializePassiveSkill
    {
        void InitSkill(IHero thisHero, IHero targetHero);
    }
}