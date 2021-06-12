using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.SkillActions.BaseClassScripts;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
    public interface ISkillConditionAsset
    {
        void Target(IHero hero);

        
    }
}