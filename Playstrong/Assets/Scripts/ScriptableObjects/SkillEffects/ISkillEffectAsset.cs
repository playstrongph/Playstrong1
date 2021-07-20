using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;

namespace ScriptableObjects.SkillEffects
{
    public interface ISkillEffectAsset
    {
        void RegisterSkillEffect(ISkill skill);

        void RegisterSkillEffect(IHero thisHero);
        
        ISkillStatus SkillReadinessReference { get; set; }


    }
}