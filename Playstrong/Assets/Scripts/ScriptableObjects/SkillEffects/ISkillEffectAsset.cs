using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Others;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using ScriptableObjects.StandardActions;
using UnityEngine;

namespace ScriptableObjects.SkillEffects
{
    public interface ISkillEffectAsset
    {
        void RegisterSkillEffect(ISkill skill);
        void RegisterSkillEffect(IHero thisHero);

        void UnregisterSkillEffect(ISkill skill);

        void UnregisterSkillEffect(IHero thisHero);
        
        //TEST
        List<ScriptableObject> StandardActionsObjects { get; }
        List<IStandardActionAsset> StandardActions { get; }
    }
}