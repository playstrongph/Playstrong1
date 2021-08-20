using System.Collections;
using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "SkillNullifier", menuName = "SO's/Status Effects/Buffs/SkillNullifier")]
    public class SkillNullifierAsset : StatusEffectAsset
    {

        [SerializeField] private float reductionValue = 100f;
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            hero.HeroLogic.HeroEvents.EPreSkillAttack += IncreaseDamageReduction;
            hero.HeroLogic.HeroEvents.EPostSkillAttack += DecreaseDamageReduction;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            hero.HeroLogic.HeroEvents.EPreSkillAttack -= IncreaseDamageReduction;
            hero.HeroLogic.HeroEvents.EPostSkillAttack -= DecreaseDamageReduction;
            
        }

        private void IncreaseDamageReduction(IHero thisHero,IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(thisHero,reductionValue));
            
        }
        
        private void DecreaseDamageReduction(IHero thisHero,IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(thisHero,-reductionValue));
        }








    }
}
