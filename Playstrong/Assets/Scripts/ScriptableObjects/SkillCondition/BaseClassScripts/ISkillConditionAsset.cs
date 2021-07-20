using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Others;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
    public interface ISkillConditionAsset
    {
        void Target(IHero thisHero, IHero targetHero);
        
        //TEST
        ISkillStatus SkillReadinessReference { get; set; }
        ISkillAttributes SkillAttributes { get; set; }
        //TEST END

        
    }
}