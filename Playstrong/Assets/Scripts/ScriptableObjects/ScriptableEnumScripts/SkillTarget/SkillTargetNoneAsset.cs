using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetNone", menuName = "SO's/Scriptable Enums/Skill Target/Skill Target None")]
    public class SkillTargetNoneAsset : ScriptableObject, ISkillTarget
    {
        private int _allyIndex = 2;
        
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
