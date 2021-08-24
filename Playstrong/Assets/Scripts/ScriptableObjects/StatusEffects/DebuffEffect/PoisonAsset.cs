using Interfaces;
using Logic;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Poison", menuName = "SO's/Status Effects/Debuffs/Poison")]
    public class PoisonAsset : StatusEffectAsset
    {
        [SerializeField] private float poisonDamage = 0;
        [SerializeField] private float percentFactor = 5f;

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn += PoisonHeroEffect;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn -= PoisonHeroEffect;
        }

        private void PoisonHeroEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            poisonDamage = percentFactor * hero.HeroLogic.HeroAttributes.BaseHealth / 100;
            poisonDamage = Mathf.CeilToInt(poisonDamage);
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, poisonDamage));
            
        }








    }
}
