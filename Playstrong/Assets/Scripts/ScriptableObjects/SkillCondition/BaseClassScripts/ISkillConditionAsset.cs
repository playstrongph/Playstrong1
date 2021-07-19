using System.Collections.Generic;
using Interfaces;
using References;
using ScriptableObjects.Others;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
    public interface ISkillConditionAsset
    {
        void Target(IHero thisHero, IHero targetHero);
        
        ISkill ReferenceSkill { get; set; }

        
    }
}