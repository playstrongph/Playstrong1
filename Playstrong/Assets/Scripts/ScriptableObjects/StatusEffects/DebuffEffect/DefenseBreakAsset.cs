using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "DefenseBreak", menuName = "SO's/Status Effects/Debuffs/DefenseBreak")]
    public class DefenseBreakAsset : StatusEffectAsset
    {

        [SerializeField] private int penetrateResistance = 1000;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, penetrateResistance));
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -penetrateResistance));
        }

        
    }
}
