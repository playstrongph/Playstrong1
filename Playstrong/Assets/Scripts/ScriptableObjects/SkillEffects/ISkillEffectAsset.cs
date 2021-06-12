using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.SkillCondition.BaseClassScripts;

namespace ScriptableObjects.SkillEffects
{
    public interface ISkillEffectAsset
    {
        void UseSkillEffect(IHero hero);

       
    }
}