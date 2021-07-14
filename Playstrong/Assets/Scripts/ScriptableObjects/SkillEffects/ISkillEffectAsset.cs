using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;

namespace ScriptableObjects.SkillEffects
{
    public interface ISkillEffectAsset
    {
        void RegisterSkillEffect(IHero thisHero, IHero targetHero, ISkill skill);

       
    }
}