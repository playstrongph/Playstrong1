using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "BombTest", menuName = "SO's/Status Effects/Debuffs/BombTest")]
    public class BombAssetTest : StatusEffectAsset
    {
        public override void ApplyStatusEffect(IHero hero) 
        {
            base.ApplyStatusEffect(hero);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            base.UnapplyStatusEffect(hero);
        }
    }
}
