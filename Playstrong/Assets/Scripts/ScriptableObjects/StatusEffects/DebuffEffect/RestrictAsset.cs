using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Restrict", menuName = "SO's/Status Effects/Debuffs/Restrict")]
    public class RestrictAsset : StatusEffectAsset
    {

        [SerializeField] private int boostEnergyResistance = 1000;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, boostEnergyResistance));
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -boostEnergyResistance));
        }

        
    }
}
