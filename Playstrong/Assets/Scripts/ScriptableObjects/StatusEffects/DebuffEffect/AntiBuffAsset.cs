using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "AntiBuff", menuName = "SO's/Status Effects/Debuffs/AntiBuff")]
    public class AntiBuffAsset : StatusEffectAsset
    {

        [SerializeField] private int buffResistance = 1000;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, buffResistance));
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -buffResistance));
        }

        
    }
}
