using Interfaces;

namespace Logic
{
    public interface ISkillEvents
    {
        event SkillEvents.SkillEvent EDragSkillTarget;
        void DragSkillTarget(IHero initiatorHero, IHero targetHero);
    }
}