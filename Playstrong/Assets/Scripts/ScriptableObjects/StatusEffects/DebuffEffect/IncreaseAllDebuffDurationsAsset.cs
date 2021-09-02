using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "IncreaseAllDebuffDurations", menuName = "SO's/Status Effects/Debuffs/IncreaseAllDebuffDurations")]
    public class IncreaseAllDebuffDurationsAsset : StatusEffectAsset
    {
        [SerializeField]
        private float increaseValue = 1f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, increaseValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
