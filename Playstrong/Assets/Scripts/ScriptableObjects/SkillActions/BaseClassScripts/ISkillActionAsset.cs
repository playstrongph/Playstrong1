using Interfaces;

namespace ScriptableObjects.SkillActions.BaseClassScripts
{
    public interface ISkillActionAsset
    {
        void Target(IHero hero);
    }
}