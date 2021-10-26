using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetAlly", menuName = "SO's/Scriptable Enums/Skill Target/Skill Target Ally")]
    public class SkillTargetAllyAsset : ScriptableObject, ISkillTarget
    {
        private int _allyIndex = 1;
        
        public void SetTargetIndex(IGetSkillTargets getSkillTargets)
        {
            getSkillTargets.TargetIndex = _allyIndex;

        }

        public GameObject SetTargetGlows(IHero hero)
        {
            var glowFrame = hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.AllyGlowFrame;
            return glowFrame;
        }

    }
}
