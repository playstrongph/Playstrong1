using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Unhealable", menuName = "SO's/Status Effects/Debuffs/Unhealable")]
    public class UnhealableAsset : StatusEffectAsset
    {

        [SerializeField] private int unhealableResistance = 1000;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, unhealableResistance));
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, unhealableResistance));
        }

        
    }
}
