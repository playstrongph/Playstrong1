using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "EnergyUp", menuName = "SO's/Status Effects/Buffs/EnergyUp")]
    public class EnergyUpAsset : StatusEffectAsset
    {
        [SerializeField]
        private float energyIncrease = 100f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, energyIncrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
