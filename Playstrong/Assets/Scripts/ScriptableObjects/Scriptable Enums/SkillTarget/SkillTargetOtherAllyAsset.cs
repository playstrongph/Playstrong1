using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetOtherAlly", menuName = "SO's/Scriptable Enums/Skill Target/SkillTargetOtherAlly")]
    public class SkillTargetOtherAllyAsset : ScriptableObject, ISkillTarget
    {
        private int _allyIndex = 3;
        
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
