using System;
using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums.SkillTarget
{
    [CreateAssetMenu(fileName = "SkillTargetEnemy", menuName = "SO's/Scriptable Enums/Skill Target/Skill Target Enemy")]
    public class SkillTargetEnemyAsset : ScriptableObject, ISkillTarget
    {
        private int _enemyIndex = 0;
        
        public void SetTargetIndex(IGetSkillTargets getSkillTargets)
        {
            getSkillTargets.TargetIndex = _enemyIndex;

        }
        
        /// <summary>
        /// Determines if frame is Normal or Taunt frame
        /// </summary>
        public GameObject SetTargetGlows(IHero hero)
        {
            var glowFrame = hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.EnemyGlowFrame;
            
            return glowFrame;
        }

    }
}

