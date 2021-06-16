using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;

namespace ScriptableObjects.SkillEffects
{
    public interface ISkillEffectAsset
    {
        void UseSkillEffect(IHero hero, ICoroutineTreesAsset coroutineTreesAsset);

       
    }
}