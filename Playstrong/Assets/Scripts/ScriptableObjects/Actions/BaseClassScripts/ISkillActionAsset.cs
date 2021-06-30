using Interfaces;
using ScriptableObjects.Others;

namespace ScriptableObjects.SkillActions.BaseClassScripts
{
    public interface ISkillActionAsset
    {
        void Target(IHero hero, ICoroutineTreesAsset coroutineTreesAsset);
    }
}