using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillEffects;

namespace Logic
{
    public interface IBasicAttack
    {
        List<float> UniqueAttackModifiers { get; }

        IEnumerator StartAttack(IHero thisHero, IHero targetHero);

        List<float> CriticalAttackModifiers { get; }

        void AddToAttackActions(IHeroAction heroAction);

        void RemoveFromAttackActions(IHeroAction heroAction);

        int SetAttackIndex { get; set; }

        ISkillStatus SkillReadiness { get; }





    }
}