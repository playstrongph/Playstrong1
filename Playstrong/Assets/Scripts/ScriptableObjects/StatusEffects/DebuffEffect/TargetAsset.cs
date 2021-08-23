using Interfaces;
using Logic;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Target", menuName = "SO's/Status Effects/Debuffs/Target")]
    public class TargetAsset : StatusEffectAsset
    {
        [SerializeField] private float criticalResistanceValue = 15f;
        [SerializeField] private float damageReductionValue = 15f;
        
        [SerializeField] private ScriptableObject decreaseDamageReductionAction;
        private IHeroAction DecreaseDamageReductionAction => decreaseDamageReductionAction as IHeroAction;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, criticalResistanceValue));
            logicTree.AddCurrent(DecreaseDamageReductionAction.StartAction(hero,damageReductionValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -criticalResistanceValue));
            logicTree.AddCurrent(DecreaseDamageReductionAction.StartAction(hero,-damageReductionValue));
        }

       





    }
}
