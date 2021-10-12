using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "EnergyDown", menuName = "SO's/Status Effects/Debuffs/EnergyDown")]
    public class EnergyDownAsset : StatusEffectAsset
    {
        [SerializeField]
        private float energyDecrease = 100f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, energyDecrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
