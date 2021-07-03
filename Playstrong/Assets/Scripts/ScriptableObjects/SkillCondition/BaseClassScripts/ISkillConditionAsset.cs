using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Others;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
    public interface ISkillConditionAsset
    {
        void Target(IHero thisHero, IHero targetHero);

        
    }
}