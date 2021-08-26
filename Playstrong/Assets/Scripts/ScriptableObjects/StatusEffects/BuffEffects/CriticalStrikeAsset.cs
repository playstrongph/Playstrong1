using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "CriticalStrike", menuName = "SO's/Status Effects/Buffs/CriticalStrike")]
    public class CriticalStrikeAsset : StatusEffectAsset
    {
        [SerializeField]
        private float increaseCriticalChance = 100;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, increaseCriticalChance));

        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -increaseCriticalChance));
        }
    }
}
