﻿using Logic;
using References;
using ScriptableObjects.SkillEffects;
using Visual;

namespace Interfaces
{
    public interface ISkillLogic
    {
        ISkillAttributes SkillAttributes { get; }
        ILoadSkillAttributes LoadSkillAttributes { get; }
        ISkill Skill { get; }
        IUpdateSkillReadiness SkillReadiness { get; }
        ISkillEvents SkillEvents { get; }
        IChangeSkillCooldown ChangeSkillCooldown { get; }

    }
}